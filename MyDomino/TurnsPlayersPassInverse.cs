using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;
using MyDomino;

namespace MyDomino
{
    public class TurnsPlayersPassInverse : ITurnsPlayers<TokenDom, (int, int), List<bool>>
    {
        public bool directionInv;
        public List<bool> players { get; set; }
        public TurnsPlayersPassInverse()
        {
            players = new List<bool>();
            directionInv = false;
        }
        public bool GetDirection()
        {
            return directionInv;
        }

        public List<bool> GetTurnsPlayers()
        {
            return players;
        }

        public void NextMove(IBoard<TokenDom, (int, int)> board)
        {
            if (board.GetRegistrer().Count != 0)
            {
                if (board.GetRegistrer()[board.GetRegistrer().Count - 1] == null) directionInv = !directionInv;
            }

            if (!directionInv)
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
            else
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i])
                    {
                        int k = i - 1;
                        if (!(k >= 0)) k = players.Count - 1;
                        players[i] = !players[i];
                        players[k] = true;
                        break;
                    }
                }

            }
        }
    }
}
