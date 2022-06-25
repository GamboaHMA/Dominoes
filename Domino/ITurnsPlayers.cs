using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public interface ITurnsPlayers<T, G, F>
    {
        public void NextMove(IBoard<T, G> board);

        public bool GetDirection();

        public F GetTurnsPlayers();
    }
}
