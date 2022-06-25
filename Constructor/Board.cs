using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;
using MyDomino;

namespace Constructor
{
    public class Board
    {
        public IBoard<TokenDom, (int, int)> board { get; set; }

        public Board(string item)
        {
            board = new BoardStandard();
        }
    }
}
