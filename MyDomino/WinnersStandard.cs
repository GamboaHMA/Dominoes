using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;
using MyDomino;

namespace MyDomino
{
    public class WinnersStandard : IWinners<TokenDom, (int, int)>
    {
        public List<IPlayer<TokenDom, (int, int)>> Winners(IBoard<TokenDom, (int, int)> board, List<IPlayer<TokenDom, (int, int)>> players)
        {
            int value = 0;
            int min_value = int.MaxValue;
            int index = 0;
            List<IPlayer<TokenDom, (int, int)>> winners = new List<IPlayer<TokenDom, (int, int)>>();

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
