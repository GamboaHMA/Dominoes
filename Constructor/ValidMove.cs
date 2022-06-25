using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;
using MyDomino;

namespace Constructor
{
    public class ValidMove
    {
        public IValidMove<TokenDom, (int, int)> validMove { get; set; }

        public ValidMove(string item)
        {
            switch (item)
            {
                case "ValidMoveStandard":
                    validMove = new ValidMoveStandard();
                    break;
                case "ValidMoveDivisible":
                    validMove = new ValidMoveDivisible();
                    break;

                default:
                    validMove = new ValidMoveStandard();
                    break;
            }
        }
    }
}
