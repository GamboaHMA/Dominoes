using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public interface IWinners<T, G>
    {
        public List<IPlayer<T, G>> Winners(IBoard<T, G> board, List<IPlayer<T, G>> players); // devuelve quien(es) son el(los) jugadores que ganaron la partida.
    }
}
