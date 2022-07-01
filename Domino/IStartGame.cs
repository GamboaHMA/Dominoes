using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public interface IStartGame<T, G, F>
    {
        public IBoard<T, G> InitializateBoard(IBoard<T, G> board);

        public void PlayerToMove(IPlayer<T, G>[] players, ITurnsPlayers<F> turn);
    }
}
