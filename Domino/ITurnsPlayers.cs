using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public interface ITurnsPlayers<F>
    {
        public void NextMove();

        public F GetTurnsPlayers();
    }
}
