using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public interface IGameOver<T, G>
    {

        public bool GameOver(IBoard<T, G> board, List<IPlayer<T, G>> players, canMove<T, G> predicate);
    }

    public delegate bool canMove<T, G>(IBoard<T, G> board, IPlayer<T, G> player);
}
