using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace MyDomino
{
    public class TokenDom: IToken<(int, int)>
    {
        public (int, int) tokenDom;

        public TokenDom((int, int) fichasdom)
        {
            tokenDom = fichasdom;
        }

        public (int, int) GetToken()
        {
            return tokenDom;
        }

        public int Value()
        {
            return tokenDom.Item1 + tokenDom.Item2;
        }

        public override string ToString()
        {
            return tokenDom.ToString();
        }

        public bool ToEquals(IToken<(int, int)> other)
        {
            if (tokenDom.Item1 == other.GetToken().Item1 && tokenDom.Item2 == other.GetToken().Item2) return true;
            else return false;
        }
    }
}
