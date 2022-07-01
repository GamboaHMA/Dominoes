using Domino;
using MyDomino;

namespace DominoProgram
{
    public partial class DominoEngine : Form
    {
        MyDom myDom = new MyDom();
              
        IRules<TokenDom, (int, int)> rules;

        IPlayer<TokenDom, (int, int)> player_turn;

        public IPlayer<TokenDom, (int, int)>[] players;

        List<TokenDom> tokens;

        IBoard<TokenDom, (int, int)> board;

        ITurnsPlayers<bool[]> turn;

        ICreatingPlayers<TokenDom, (int, int)> creatingPlayers;

        IStartGame<TokenDom, (int, int), bool[]> startGame;

        int totalTokensForPlayers;
        int totalPlayers;
        int totalTokens;

        string p = "player";
        string tok = "tokens:";

        public DominoEngine()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TotalPlayers.Items.Add(4);
            TotalPlayers.Items.Add(3);
            TotalPlayers.Items.Add(2);
            TotalPlayers.Items.Add(1);

            TotalTokens.Items.Add(6);
            TotalTokens.Items.Add(9);

            TotalTokensForPlayer.Items.Add(7);
            TotalTokensForPlayer.Items.Add(8);
            TotalTokensForPlayer.Items.Add(9);
            TotalTokensForPlayer.Items.Add(10);
            lblGameOver.Text = "";
            btnStartGame.Text = "StartGame";
            
        }



        private void TotalPlayers_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void play_butt_Click(object sender, EventArgs e)
        {
            rules = myDom.DefineRules();

            // Total of Players
            if (int.TryParse(TotalPlayers.Text, out totalPlayers))
            {
                totalPlayers = int.Parse(TotalPlayers.Text);
            }
            else throw new Exception("Check the total of players");

            // Total of Tokens for Players
            if (int.TryParse(TotalTokensForPlayer.Text, out totalTokensForPlayers))
            {
                totalTokensForPlayers = int.Parse(TotalTokensForPlayer.Text);
            }
            else throw new Exception("Check the total of tokens for players");

            creatingPlayers = myDom.CreatingPlayers();
            players = creatingPlayers.InitializePlayers(players, totalPlayers);
            for (int i = 0; i < players.Length; i++)
            {
                 treePlayers.Nodes.Add($"{players[i]}");

            }

            // Total of Tokens
            if (int.TryParse(TotalTokens.Text, out totalTokens))
            {
                totalTokens = int.Parse(TotalTokens.Text);
                tokens = rules.Tokens(totalTokens);
            }
            else throw new Exception("Check the total of tokens");

            // Repartir fichas

            distributeTokens.Enabled = true;
            btnInitialitePlayersTokens.Enabled = false;
        }

        private void distributeTokens_Click(object sender, EventArgs e)
        {
            rules.DistributeTokens(tokens, players, totalTokensForPlayers);
            distributeTokens.Enabled = false;
            PlayersVisualUpdate(players, turn);

            btnStartGame.Enabled = btnStartGame.Visible = true;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            turn = myDom.TurnPlayers(players);
            startGame = myDom.StartGame();
            board = startGame.InitializateBoard(board);
            lblActuallyTable.Text = $"ActuallyTable: {board.GetActuallyBoard()}";
            startGame.PlayerToMove(players, turn);

            PlayersVisualUpdate(players ,turn);

            btnNextMove.Visible = true;
            btnNextMove.Enabled = true;
            btnStartGame.Enabled = false;
        }

        private void bttnNextMove_Click(object sender, EventArgs e)
        {
            if (rules.GameOver(board, players)) GameOver();

            if (rules.CanMove(board, player_turn))
            {
                var move = player_turn.Play(board, player_turn.GetHand());
                player_turn.GetHand().Remove(move.Item1);
                board.UpdateBoard(move);
                lstMoves.Items.Add($"{move.Item1} {player_turn} {board.GetActuallyBoard()}");
                lblActuallyTable.Text = board.GetActuallyBoard().ToString();
                turn.NextMove();
                PlayersVisualUpdate(players, turn);
            }

            else
            {
                var move = player_turn.Play(board, player_turn.GetHand());
                board.UpdateBoard(move);
                lstMoves.Items.Add($"pass  {player_turn} {lblActuallyTable.Text}");
                turn.NextMove();
                PlayersVisualUpdate(players, turn);
            }

            if (rules.GameOver(board, players)) GameOver();
        }

        public void PlayersVisualUpdate(IPlayer<TokenDom, (int, int)>[] players, ITurnsPlayers<bool[]> turn)
        {
            for (int i = 0; i < players.Length; i++)
            {
                treePlayers.Nodes[i] = new TreeNode();
                if (turn != null && turn.GetTurnsPlayers()[i] ) { treePlayers.Nodes[i].Text = $"{p} {i + 1} ({tok} {players[i].GetHand().Count}) playNow"; player_turn = players[i]; }
                else treePlayers.Nodes[i].Text = $"{p} {i + 1} ({tok} {players[i].GetHand().Count})";
                for (int j = 0; j < players[i].GetHand().Count; j++)
                {
                    treePlayers.Nodes[i].Nodes.Add(players[i].GetHand()[j].ToString());
                }
            }
        }

        public void GameOver()
        {
            btnStartGame.Text = "ResetGame";
            //btnStartGame.Enabled = true;
            btnNextMove.Enabled = false;
            IPlayer<TokenDom, (int, int)>[] wineers = rules.Winners(board, players);

            lblGameOver.Text += "TheWinner(s)Is(Are):";
            for (int i = 0; i < wineers.Length; i++)
            {
                lblGameOver.Text += " " + wineers[i].ToString() ;
            }
        }
    }
}