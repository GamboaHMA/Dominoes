using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public interface IRules<T, G>
    {
        public List<T> Tokens(int c);                                                        // genera las fichas dependiendo de la cantidad de fichas que se le pase como parametro

        public void DistributeTokens(List<T> tokens, List<IPlayer<T, G>> players, int cant); // reparte las fichas a partir de total que devuelve el metodo ".Tokens(...)" entre todos los jugadores

        public IPlayer<T, G>[] Winners(IBoard<T, G> board, List<IPlayer<T, G>> players);     // devuelve el(los) jugador(es) que gan(o)(aron) la partida

    }
}
