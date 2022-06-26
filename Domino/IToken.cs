using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public interface IToken<G>
    {
        public int Value();                     // devuelve el valor de la ficha

        public bool ToEquals(IToken<G> other);  // comprueba si dos fichas son iguales

        public G GetToken();                    // devuelve el valor almacenado en una ficha
    }
}
