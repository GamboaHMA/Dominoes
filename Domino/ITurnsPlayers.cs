using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public interface ITurnsPlayers<T, G, F>
    {
        public void NextMove(IBoard<T, G> board); // modifica el valor devuelto por el metodo ".GetTurnsPlayers()"

        public bool GetDirection();               // devuelve el sentido de la mesa

        public F GetTurnsPlayers();               // devuelve una coleccion que me permite saber a que jugador le toca jugar
    }
}
