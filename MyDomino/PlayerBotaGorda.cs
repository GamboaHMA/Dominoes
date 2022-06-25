using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;
using MyDomino;

namespace MyDomino
{
    public class PlayerBotaGorda : IPlayer<TokenDom, (int, int)>
    {
        public List<TokenDom> tokens;
        public bool winner;
        RulesStandard rules = new RulesStandard();
        public string name { get; set; }

        public PlayerBotaGorda(List<TokenDom> tokens, string name)
        {
            this.tokens = tokens;
            this.name = name;
        }

        public (TokenDom, int) Euristic(IBoard<TokenDom, (int, int)> board, List<TokenDom> moves)
        {
            if (moves.Count == 0) return (null, -1);
            (TokenDom, int) result;
            TokenDom maxMove = new TokenDom((-1000, -1000));

            foreach (var token in moves)
            {
                if (token.Value() > maxMove.Value()) maxMove = token;
            }
            result.Item1 = moves[moves.IndexOf(maxMove)];

            (int, int) board_ = board.GetActuallyBoard();
            if (board_.Item1 == -1 || board_.Item2 == -1) result.Item2 = -1;
            else if (board_.Item1 == result.Item1.tokenDom.Item1) result.Item2 = board_.Item1;
            else if (board_.Item1 == result.Item1.tokenDom.Item2) result.Item2 = board_.Item2;
            else result.Item2 = board_.Item2;

            return result;
        }

        public List<TokenDom> GetHand()
        {
            return tokens;
        }

        public bool GetWinner()
        {
            return winner;
        }

        public (TokenDom, int) Play(IBoard<TokenDom, (int, int)> board, List<TokenDom> hand)
        {
            List<TokenDom> moves = new List<TokenDom>();
            foreach (TokenDom token in hand)
            {
                if (rules.ValidMove(board, token)) moves.Add(token);
            }

            return Euristic(board, moves);
        }

        public bool ToEquals(IPlayer<TokenDom, (int, int)> other)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].ToEquals(other.GetHand()[i])) continue;
                else return false;
            }
            return true;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
