using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public interface IBoard<T, G>
    {
        public void UpdateBoard((T, int) move);

        public G GetActuallyBoard();

        public List<T> GetRegistrer();
    }
}
