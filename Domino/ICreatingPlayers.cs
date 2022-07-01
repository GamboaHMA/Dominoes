using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public interface ICreatingPlayers<T, G>
    {
        public IPlayer<T, G>[] InitializePlayers(IPlayer<T, G>[] players, int totalPlayers);
    }
}
