using Domino;
using MyDomino;
using Constructor;

namespace DominoProgram
{
    public partial class DominoEngine : Form
    {
        MyDom myDom = new MyDom();
        
        Rules rules_;

        //IPlayer<TokenDom, (int, int)> player_turn;
        Player player_turn_ = new Player();

        //public IPlayer<TokenDom, (int, int)>[] players;
        PlayerList players_ = new PlayerList();

        List<TokenDom> tokens;

        //IBoard<TokenDom, (int, int)> board;
        Board board_;

        //ITurnsPlayers<List<bool>> turn;
        TurnsPlayers turn_;

        //ICreatingPlayers<TokenDom, (int, int)> creatingPlayers;

        //IStartGame<TokenDom, (int, int), List<bool>> startGame;
        StartGame startGame_;

        GameOver gameOver;

        ValidMove validMove;

        Winners winners;

        int totalTokensForPlayers;
        int totalTokens;

        string p = "player";
        string tok = "tokens:";

        public DominoEngine()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 6; i < 13; i++)
                TotalTokens.Items.Add(i);

            for (int i = 7; i < 16; i++)
                TotalTokensForPlayer.Items.Add(i);

            lblGameOver.Text = "";
            btnStartGame.Text = "StartGame";

//------------------------------------------------

            ComboRules.Items.Add("RulesStandar");

            comboPlayers.Items.Add("PlayerRandom");
            comboPlayers.Items.Add("PlayerBotaGorda");
            comboPlayers.Items.Add("PlayerBotaGorda_Random");

            comboNextTurn.Items.Add("TurnsPLayersStandar");
            comboNextTurn.Items.Add("TurnsPlayersPassInverse");

            comboGameOver.Items.Add("GameOverStandar");
            comboGameOver.Items.Add("GameOverPass");

            comboValidMove.Items.Add("ValidMoveStandard");
            comboValidMove.Items.Add("ValidMoveDivisible");

            comboWinners.Items.Add("WinnersStandard");
            comboWinners.Items.Add("WinnersMaxPoints");
            comboWinners.Items.Add("WinnersMinorDoble");
        }



        private void TotalPlayers_SelectedItemChanged(object sender, EventArgs e)
        {

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Player player = new Player(comboPlayers.Text);
            players_.players.Add(player.player);
            btnDone.Enabled = true;
            treePlayers.Nodes.Add($"{player.player} {players_.players.Count}");
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnDone.Enabled = false;
        }

        private void play_butt_Click(object sender, EventArgs e)
        {
            rules_ = new Rules(ComboRules.Text);
            board_ = new Board("");
            turn_ = new TurnsPlayers(comboNextTurn.Text);            
            for (int i = 0; i < players_.players.Count; i++)
                turn_.turnsPlayers.GetTurnsPlayers().Add(false);
            startGame_ = new StartGame("");
            gameOver = new GameOver(comboGameOver.Text);
            validMove = new ValidMove(comboValidMove.Text);
            winners = new Winners(comboWinners.Text);

            // Total of Tokens for Players
            if (int.TryParse(TotalTokensForPlayer.Text, out totalTokensForPlayers))
            {
                totalTokensForPlayers = int.Parse(TotalTokensForPlayer.Text);
            }
            else throw new Exception("Check the total of tokens for players");

            // Total of Tokens
            if (int.TryParse(TotalTokens.Text, out totalTokens))
            {
                totalTokens = int.Parse(TotalTokens.Text);
                tokens = rules_.rules.Tokens(totalTokens);
            }
            else throw new Exception("Check the total of tokens");

            // Repartir fichas

            distributeTokens.Enabled = true;
        }

        private void distributeTokens_Click(object sender, EventArgs e)
        {
            rules_.rules.DistributeTokens(tokens, players_.players, totalTokensForPlayers);
            distributeTokens.Enabled = false;
            PlayersVisualUpdate(players_, turn_);

            btnInitialitePlayersTokens.Enabled = false;
            btnStartGame.Enabled = btnStartGame.Visible = true;
            btnDone.Enabled = false;
            btnAdd.Enabled = false;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            //turn = myDom.TurnPlayers(players_.players);


            //startGame = myDom.StartGame();
            board_.board = startGame_.startGame.InitializateBoard(board_.board);
            lblActuallyTable.Text = $"ActuallyTable: {board_.board.GetActuallyBoard()}";
            startGame_.startGame.PlayerToMove(players_.players, turn_.turnsPlayers);

            PlayersVisualUpdate(players_ ,turn_);

            btnNextMove.Visible = true;
            btnNextMove.Enabled = true;
            btnStartGame.Enabled = false;
        }

        private void bttnNextMove_Click(object sender, EventArgs e)
        {
            if (gameOver.gameOver.GameOver(board_.board, players_.players, (board, player) => validMove.validMove.CanMove(board, player))) GameOver();

            if (validMove.validMove.CanMove(board_.board, player_turn_.player))
            {
                var move = player_turn_.player.Play(board_.board, player_turn_.player.GetHand());
                player_turn_.player.GetHand().Remove(move.Item1);
                board_.board.UpdateBoard(move);
                lstMoves.Items.Add($"{move.Item1} {player_turn_.player}{players_.players.IndexOf(player_turn_.player) + 1} {board_.board.GetActuallyBoard()}");
                lblActuallyTable.Text = board_.board.GetActuallyBoard().ToString();
                turn_.turnsPlayers.NextMove(board_.board);
                PlayersVisualUpdate(players_, turn_);
            }

            else
            {
                var move = player_turn_.player.Play(board_.board, player_turn_.player.GetHand());
                board_.board.UpdateBoard(move);
                lstMoves.Items.Add($"pass  {player_turn_.player} {lblActuallyTable.Text}");
                turn_.turnsPlayers.NextMove(board_.board);
                PlayersVisualUpdate(players_, turn_);
            }
            
            if (gameOver.gameOver.GameOver(board_.board, players_.players, (board, player) => validMove.validMove.CanMove(board, player))) GameOver();
        }

        public void PlayersVisualUpdate(PlayerList players, TurnsPlayers turn)
        {
            for (int i = 0; i < players.players.Count; i++)
            {
                treePlayers.Nodes[i] = new TreeNode();
                if (turn != null && turn.turnsPlayers.GetTurnsPlayers()[i] ) { treePlayers.Nodes[i].Text = $"{players.players[i]} {i + 1} ({tok} {players.players[i].GetHand().Count}) playNow"; player_turn_.player = players.players[i]; }
                else treePlayers.Nodes[i].Text = $"{players.players[i]} {i + 1} ({tok} {players.players[i].GetHand().Count})";
                for (int j = 0; j < players.players[i].GetHand().Count; j++)
                {
                    treePlayers.Nodes[i].Nodes.Add(players.players[i].GetHand()[j].ToString());
                }
            }
        }

        public void GameOver()
        {
            btnStartGame.Text = "ResetGame";
            //btnStartGame.Enabled = true;
            btnNextMove.Enabled = false; 
            List<IPlayer<TokenDom, (int, int)>> wineers = winners.winners.Winners(board_.board, players_.players);

            lblGameOver.Text += "TheWinner(s)Is(Are):";
            for (int i = 0; i < wineers.Count; i++)
            {
                lblGameOver.Text += " " + wineers[i].ToString() + (i + 1) ;
            }
        }

    }
}