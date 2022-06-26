using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public interface IPlayer<T, G>
    {
        public (T, int) Play(IBoard<T, G> board, List<T> hand, IValidMove<T, G> validMove); // metodo que utilizando las fichas que tiene un jugador dado devuelve una de
                                                                                            // ellas valida, usando el metodo ".Euristic(..)".

        public (T, int) Euristic(IBoard<T, G> board, List<T> moves);                        // utilizando el tablero y un conjunto de fichas validas a jugar, devuelve una
                                                                                            // ficha basandose en el tipo de jugador que se haya implementado

        public bool ToEquals(IPlayer<T, G> other);                                          // evalua si dos jugadores son iguales basandose en el criterio implementadp

        public List<T> GetHand();                                                           // devuelve las fichas que posee el jugador

        public string ToString();                                                           // devuelve el nombre por el que el jugador sera nombrado

        public bool GetWinner();                                                            // devuelve si el jugador gano la anterior partida
    }
}
