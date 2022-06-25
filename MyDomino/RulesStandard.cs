using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace MyDomino
{
    public class RulesStandard: IRules<TokenDom, (int, int)>
    {


        public List<TokenDom> Tokens(int c)
        {
            List<TokenDom> tokens = new List<TokenDom>();
            for (int i = 0; i < c + 1; i++)
                for (int j = i; j < c + 1; j++)
                {
                    tokens.Add(new TokenDom((i, j)));
                }

            return tokens;
        }

        public void DistributeTokens(List<TokenDom> tokens, List<IPlayer<TokenDom, (int, int)>> players, int cant)
        {
            if (cant * players.Count > tokens.Count) { throw new Exception("The tokens are not enough"); }

            foreach (var player in players)
            {
                for (int i = 0; i < cant; i++)
                {
                    Random random = new Random();
                    int random_ = random.Next(tokens.Count);
                    player.GetHand().Add(tokens[random_]);
                    tokens.RemoveAt(random_);
                }
            }
        }

        public bool ValidMove(IBoard<TokenDom, (int, int)> board, IToken<(int, int)> token)
        {
            (int, int) actuallyBoard = board.GetActuallyBoard();
            if (actuallyBoard.Item1 == actuallyBoard.Item2 && actuallyBoard.Item1 == -1) return true;
            else if (actuallyBoard.Item1 == token.GetToken().Item1 || actuallyBoard.Item1 == token.GetToken().Item2) return true;
            else if (actuallyBoard.Item2 == token.GetToken().Item1 || actuallyBoard.Item2 == token.GetToken().Item2) return true;
            else return false;
        }

        public bool CanMove(IBoard<TokenDom, (int, int)> board, IPlayer<TokenDom, (int, int)> player)
        {
            foreach (var token in player.GetHand())
            {
                if (ValidMove(board, token)) return true;
            }
            return false;
        }

        public bool GameOver(IBoard<TokenDom, (int, int)> board, List<IPlayer<TokenDom, (int, int)>> players)
        {
            int count = 0;
            foreach (var player in players)
            {
                if (player.GetHand().Count == 0) return true;
                if (!CanMove(board, player)) count++;
            }
            if (count == players.Count) return true;

            return false;
        }

        public IPlayer<TokenDom, (int, int)>[] Winners(IBoard<TokenDom, (int, int)> board, List<IPlayer<TokenDom, (int, int)>> players)
        {
            int value = 0;
            int min_value = int.MaxValue;
            int index = 0;
            IPlayer<TokenDom, (int, int)>[] winners;

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].GetHand().Count == 0) { winners = new PlayerRandom[1]; winners[0] = players[i]; return winners; }
                
                
                    foreach (var token in players[i].GetHand())
                    {
                        value += token.Value();
                    }
                    if (value < min_value) { min_value = value; index = i; }
                    value = 0;
                

            }
            winners = new PlayerRandom[1]; winners[0] = players[index];
            return winners;
        }
    }
}
