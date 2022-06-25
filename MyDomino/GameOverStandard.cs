using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace MyDomino
{
    public class GameOverStandard : IGameOver<TokenDom, (int, int)>
    {
        public bool GameOver(IBoard<TokenDom, (int, int)> board, List<IPlayer<TokenDom, (int, int)>> players, canMove<TokenDom, (int, int)> predicate)
        {
            int count = 0;

            foreach (var player in players)
            {
                if (player.GetHand().Count == 0) return true;
                if (!predicate(board, player)) count++;
            }
            if (count == players.Count) return true;

            return false;
        }
    }
}
