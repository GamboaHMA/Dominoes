using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;
using MyDomino;

namespace Constructor
{
    public class Token
    {
        public IToken<(int, int)> token { get; set; }

        //public Token(string item)
        //{
        //    token = new TokenDom()
        //}
    }
}
