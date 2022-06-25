using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public interface IValidMove<T, G>
    {
        public bool CanMove(IBoard<T, G> board, IPlayer<T, G> player);

        public bool ValidMove(IBoard<T, G> board, IToken<G> token);
    }
}
