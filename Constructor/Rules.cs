using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;
using MyDomino;

namespace Constructor
{

    public class Rules
    {
        public IRules<TokenDom, (int, int)> rules { get; set; }

        public Rules(string item)
        {
            switch (item)
            {
                case "RulesStandar": rules = new RulesStandard();
                    break;

                default:
                    rules = new RulesStandard();
                    break;
            }
        }

    }
}
