using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public interface IRules<T, G>
    {
        public List<T> Tokens(int c);

        public void DistributeTokens(List<T> tokens, List<IPlayer<T, G>> players, int cant);

        public IPlayer<T, G>[] Winners(IBoard<T, G> board, List<IPlayer<T, G>> players);

    }
}
