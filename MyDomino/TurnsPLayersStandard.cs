using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace MyDomino
{
    public class TurnsPLayersStandard: ITurnsPlayers<TokenDom, (int, int), List<bool>>
    {
        public List<bool> players { get; set; }

        public bool directionInv;

        public TurnsPLayersStandard()
        {
            players = new List<bool>();
            directionInv = false;
        }

        public void NextMove(IBoard<TokenDom, (int, int)> board)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i])
                {
                    int k = i + 1;
                    if (!(k < players.Count)) k = 0;
                    players[i] = !players[i];
                    players[k] = true;
                    break;
                }
            }
        }

        public List<bool> GetTurnsPlayers()
        {
            return players;
        }

        public bool GetDirection()
        {
            return directionInv;
        }
    }
}
