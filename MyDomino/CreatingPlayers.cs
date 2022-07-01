using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;


namespace MyDomino
{
    public class CreatingPlayers: ICreatingPlayers<TokenDom, (int, int)>
    {
        public IPlayer<TokenDom, (int, int)>[] InitializePlayers(IPlayer<TokenDom, (int, int)>[] players, int totalOfPlayers)
        {
            players = new Player[totalOfPlayers];
            for (int i = 0; i < totalOfPlayers; i++)
            {
                players[i] = new Player(new List<TokenDom>(), "player" + (i + 1));
            }
            return players;
        }
    }
}
