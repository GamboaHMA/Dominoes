using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace MyDomino
{
    public class PlayerRandom: IPlayer<TokenDom, (int, int)>
    {
        public List<TokenDom> tokens;
        public bool winner;
        public string name { get; set; }

        public PlayerRandom(List<TokenDom> tokens, string name)
        {
            this.tokens = tokens;
            this.name = name;
        }

        public (TokenDom, int) Play(IBoard<TokenDom, (int, int)> board, List<TokenDom> hand, IValidMove<TokenDom, (int, int)> validMove)
        {
            List<TokenDom> moves = new List<TokenDom>();
            foreach (TokenDom token in hand)
            {
                if (validMove.ValidMove(board, token)) moves.Add(token);
            }

            return Euristic(board, moves);
        }

        public (TokenDom, int) Euristic(IBoard<TokenDom, (int, int)> board, List<TokenDom> moves)
        {
            if (moves.Count == 0) return (null, -1);
            (TokenDom, int) result;
            Random random = new Random();
            int random_ = random.Next(moves.Count);
            result.Item1 = moves[random_];
            (int, int) board_ = board.GetActuallyBoard();
            if (board_.Item1 == -1 || board_.Item2 == -1) result.Item2 = -1;
            else if (board_.Item1 == moves[random_].tokenDom.Item1) result.Item2 = board_.Item1;
            else if (board_.Item1 == moves[random_].tokenDom.Item2) result.Item2 = board_.Item2;
            else result.Item2 = board_.Item2;

            return result;
        }

        public bool ToEquals(IPlayer<TokenDom, (int, int)> other)
        {

            for (int i = 0; i < tokens.Count; i++)
            {
                if (other.GetHand().Contains(tokens[i])) continue;
                else return false;
            }
        return true;
        }

        public List<TokenDom> GetHand()
        {
            return tokens;
        }
        public override string ToString()
        {
            return name;
        }

        public bool GetWinner()
        {
            return winner;
        }
    }

}