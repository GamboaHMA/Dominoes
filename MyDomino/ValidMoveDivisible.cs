using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;
using MyDomino;

namespace MyDomino
{
    public class ValidMoveDivisible : IValidMove<TokenDom, (int, int)>
    {
        public bool CanMove(IBoard<TokenDom, (int, int)> board, IPlayer<TokenDom, (int, int)> player)
        {
            foreach (var token in player.GetHand())
            {
                if (ValidMove(board, token)) return true;
            }
            return false;
        }

        public bool ValidMove(IBoard<TokenDom, (int, int)> board, IToken<(int, int)> token)
        {
            (int, int) actuallyBoard = board.GetActuallyBoard();
            if (actuallyBoard.Item1 == actuallyBoard.Item2 && actuallyBoard.Item1 == -1) return true;
            else if (token.GetToken().Item1 != 0)
            {
                if ((actuallyBoard.Item1 % token.GetToken().Item1 == 0) || (actuallyBoard.Item2 % token.GetToken().Item1 == 0)) return true;
            }
            else if (actuallyBoard.Item1 == 0 || actuallyBoard.Item2 == 0) return true;
            else if (token.GetToken().Item2 != 0)
            {
                if ((actuallyBoard.Item1 % token.GetToken().Item2 == 0) || (actuallyBoard.Item2 % token.GetToken().Item2 == 0)) return true;
            }
            else if (actuallyBoard.Item1 == 0 || actuallyBoard.Item2 == 0) return true;

            return false;
        }
    }
}
