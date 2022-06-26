using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public interface IBoard<T, G>
    {
        public void UpdateBoard((T, int) move);  // encargado de actualizar el valor actual de la mesa usando la variable "move"

        public G GetActuallyBoard();             // devuelve el valor actual de la mesa

        public List<T> GetRegistrer();           // devuelve todas las fichas que se han jugado hasta el momento
    }
}
