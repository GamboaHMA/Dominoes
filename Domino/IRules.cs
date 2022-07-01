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

        public void DistributeTokens(List<T> tokens, IPlayer<T, G>[] players, int cant);

        public bool ValidMove(IBoard<T, G> board, IToken<G> token);

        public bool CanMove(IBoard<T, G> board, IPlayer<T, G> player);

        public bool GameOver(IBoard<T, G> board, IPlayer<T, G>[] players);

        public IPlayer<T, G>[] Winners(IBoard<T, G> board, IPlayer<T, G>[] players);

    }
}
