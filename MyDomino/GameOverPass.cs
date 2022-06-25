using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace MyDomino
{
    public class GameOverPass : IGameOver<TokenDom, (int, int)>
    {
        public bool GameOver(IBoard<TokenDom, (int, int)> board, List<IPlayer<TokenDom, (int, int)>> players, canMove<TokenDom, (int, int)> predicate)
        {
            if (board.GetRegistrer().Count != 0)
            {
            if (board.GetRegistrer()[board.GetRegistrer().Count - 1] == null ) return true;
            }

            return false;
        }
    }
}
