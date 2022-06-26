using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace MyDomino
{
    public class BoardStandard: IBoard<TokenDom, (int, int)>
    {
        public List<TokenDom> registrer;

        public (int, int) actuallyBoard;

        public BoardStandard ()
        {
            registrer = new List<TokenDom>();
            actuallyBoard = (-1, -1);
        }

        public void UpdateBoard((TokenDom, int) move)
        {
            int actual;
            registrer.Add(move.Item1);
            if (move.Item1 != null)
            {
            if (move.Item1.tokenDom.Item1 == move.Item2) actual = move.Item1.tokenDom.Item2;
            else actual = move.Item1.tokenDom.Item1;

            if (actuallyBoard.Item1 == move.Item2) actuallyBoard.Item1 = actual;
            else actuallyBoard.Item2 = actual;

            if (move.Item2 == -1) actuallyBoard = move.Item1.tokenDom;
            }
        }

        public (int, int) GetActuallyBoard()
        {
            return actuallyBoard;
        }

        public List<TokenDom> GetRegistrer()
        {
            return registrer;
        }
    }
}
