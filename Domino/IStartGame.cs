using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public interface IStartGame<T, G, F>
    {
        public IBoard<T, G> InitializateBoard(IBoard<T, G> board);                          // le da un valor inicial a la mesa

        public void PlayerToMove(List<IPlayer<T, G>> players, ITurnsPlayers<T, G, F> turn); // define dependiendo de como este implementado el jugador que comenzara a jugar
    }
}
