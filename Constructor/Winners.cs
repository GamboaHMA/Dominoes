using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;
using MyDomino;

namespace Constructor
{
    public class Winners
    {
        public IWinners<TokenDom, (int, int)> winners { get; set; }

        public Winners(string item)
        {
            switch (item)
            {
                case "WinnersStandard":
                    winners = new WinnersStandard();
                    break;
                case "WinnersMaxPoints":
                    winners = new WinnersMaxPoints();
                    break;
                case "WinnersMinorDoble":
                    winners = new WinnersMinorDoble();
                    break;

                default:
                    winners = new WinnersStandard();
                    break;
            }
        }
    }
}
