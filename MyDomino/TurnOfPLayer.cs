using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace MyDomino
{
    public class TurnOfPlayer: ITurnsPlayers<bool[]>
    {
        public bool[] players;

        public TurnOfPlayer(IPlayer<TokenDom, (int, int)>[] players)
        {
            this.players = new bool[players.Length];
        }

        public void NextMove()
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i])
                {
                    int k = i + 1;
                    if (!(k < players.Length)) k = 0;
                    players[i] = !players[i];
                    players[k] = true;
                    break;
                }
            }
        }

        public bool[] GetTurnsPlayers()
        {
            return players;
        }
    }
}
