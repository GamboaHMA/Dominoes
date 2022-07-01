using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public interface IToken<G>
    {
        public int Value();

        public bool ToEquals(IToken<G> other);

        public G GetToken();
    }
}
