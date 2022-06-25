using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;
using MyDomino;

namespace MyDomino
{
    public class WinnersMinorDoble: IWinners<TokenDom, (int, int)>
    {
        public List<IPlayer<TokenDom, (int, int)>> Winners(IBoard<TokenDom, (int, int)> board, List<IPlayer<TokenDom, (int, int)>> players)
        {
            List<IPlayer<TokenDom, (int, int)>> winners = new List<IPlayer<TokenDom, (int, int)>>();
            TokenDom minorDoble = new TokenDom((1000, 1000));
            int index_ = 0;

            for (int i = 0; i < players.Count; i++)
            {
                foreach (var token in players[i].GetHand())
                {
                    if(token.GetToken().Item1 == token.GetToken().Item2)
                    {
                        if (token.Value() < minorDoble.Value()) { minorDoble = token; index_ = i; }
                    }
                }
            }
            if (minorDoble.tokenDom.Item1 != 1000)
            {
                winners.Add(players[index_]);
                return winners;
            }

            int value = 0;
            int min_value = int.MaxValue;
            int index = 0;

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].GetHand().Count == 0) { winners.Add(players[i]); return winners; }


                foreach (var token in players[i].GetHand())
                {
                    value += token.Value();
                }
                if (value < min_value) { min_value = value; index = i; }
                value = 0;


            }
            winners.Add(players[index]);
            return winners;
        }

    }
}
