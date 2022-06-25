using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace MyDomino
{
    public class PlayerBotaGorda_Random: IPlayer<TokenDom, (int, int)>
    {
        public List<TokenDom> tokens;
        public bool winner;
        RulesStandard rules = new RulesStandard();
        public string name { get; set; }

        public PlayerBotaGorda_Random(List<TokenDom> tokens, string name)
        {
            this.tokens = tokens;
            this.name = name;
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

        public (TokenDom, int) Euristic(IBoard<TokenDom, (int, int)> board, List<TokenDom> moves)
        {
            Random bi = new Random();
            int bi_ = bi.Next(2);

            switch (bi_)
            {
                case 0:
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
                    break;
                
                default:
                    if (moves.Count == 0) return (null, -1);
                    (TokenDom, int) result_;
                    TokenDom maxMove = new TokenDom((-1000, -1000));

                    foreach (var token in moves)
                    {
                        if (token.Value() > maxMove.Value()) maxMove = token;
                    }
                    result_.Item1 = moves[moves.IndexOf(maxMove)];

                    (int, int) board__ = board.GetActuallyBoard();
                    if (board__.Item1 == -1 || board__.Item2 == -1) result_.Item2 = -1;
                    else if (board__.Item1 == result_.Item1.tokenDom.Item1) result_.Item2 = board__.Item1;
                    else if (board__.Item1 == result_.Item1.tokenDom.Item2) result_.Item2 = board__.Item2;
                    else result_.Item2 = board__.Item2;

                    return result_;
                    break;
            }

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
