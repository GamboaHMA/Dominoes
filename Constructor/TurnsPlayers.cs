using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;
using MyDomino;

namespace Constructor
{
    public class TurnsPlayers
    {
        public ITurnsPlayers<TokenDom, (int, int), List<bool>> turnsPlayers { get; set; }

        public TurnsPlayers(string item)
        {
            switch (item)
            {
                case "TurnsPLayersStandar":
                    turnsPlayers = new TurnsPLayersStandard();
                    break;
                case "TurnsPlayersPassInverse":
                    turnsPlayers = new TurnsPlayersPassInverse();
                    break;

                default:
                    turnsPlayers = new TurnsPLayersStandard();
                    break;
            }
        }
    }
}
