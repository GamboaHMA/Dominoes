using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public interface IPlayer<T, G>
    {
        public (T, int) Play(IBoard<T, G> board, List<T> hand);

        public (T, int) Euristic(IBoard<T, G> board, List<T> moves);

        public bool ToEquals(IPlayer<T, G> other);

        public List<T> GetHand();

        public string ToString();

        public bool GetWinner();
    }
}
