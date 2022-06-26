using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace MyDomino
{
    public class RulesDistributeDobles : IRules<TokenDom, (int, int)>
    {
        public void DistributeTokens(List<TokenDom> tokens, List<IPlayer<TokenDom, (int, int)>> players, int cant)
        {
            if (cant * players.Count > tokens.Count) { throw new Exception("The tokens are not enough"); }

            foreach (var player in players)
            {
                for (int i = 0; i < cant; i++)
                {
                    if (TodosDobles(tokens))
                    {
                        Random random1 = new Random();
                        int random_1 = random1.Next(tokens.Count);
                        player.GetHand().Add(tokens[random_1]);
                        tokens.RemoveAt(random_1);
                    }
                    Random random = new Random();
                    int random_ = random.Next(tokens.Count);
                    if (!(EsDoble(tokens[random_].GetToken()) && DosDobles(player.GetHand()))) 
                    {
                    player.GetHand().Add(tokens[random_]);
                    tokens.RemoveAt(random_);
                    }
                    else  i--; 
                }
            }
        }
        public bool TodosDobles(List<TokenDom> tokens)
        {
            foreach (var token in tokens)
            {
                if (!EsDoble(token.tokenDom)) return false;
            }
            return true;
        }

        public bool EsDoble((int, int) token)
        {
            if (token.Item1 == token.Item2) return true;
            else return false;
        }

        public bool DosDobles(List<TokenDom> hand)
        {
            int count = 0;
            foreach (var token in hand)
            {
                if (EsDoble(token.GetToken())) count++;
                if (count >= 2) return true;
            }
            return false;
        }

        public List<TokenDom> Tokens(int c)
        {
            List<TokenDom> tokens = new List<TokenDom>();
            for (int i = 0; i < c + 1; i++)
                for (int j = i; j < c + 1; j++)
                {
                    tokens.Add(new TokenDom((i, j)));
                }

            return tokens;
        }

        public IPlayer<TokenDom, (int, int)>[] Winners(IBoard<TokenDom, (int, int)> board, List<IPlayer<TokenDom, (int, int)>> players)
        {
            throw new NotImplementedException();
        }
    }
}
