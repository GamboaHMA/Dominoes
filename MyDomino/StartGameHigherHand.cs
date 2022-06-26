using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace MyDomino
{
    public class StartGameHigherHand : IStartGame<TokenDom, (int, int), List<bool>>
    {
        public IBoard<TokenDom, (int, int)> InitializateBoard(IBoard<TokenDom, (int, int)> board)
        {
            board = new BoardStandard();
            return board;
        }

        public void PlayerToMove(List<IPlayer<TokenDom, (int, int)>> players, ITurnsPlayers<TokenDom, (int, int), List<bool>> turn)
        {
            int index = 0;
            int maxValue = int.MinValue;
            foreach (var player in players)
            {
                if (ValorMano(player) >= maxValue) { maxValue = ValorMano(player);  index = players.IndexOf(player); }
            }
            turn.GetTurnsPlayers()[index] = true;
        }

        public int ValorMano(IPlayer<TokenDom, (int, int)> player)
        {
            int value = 0;
            foreach (var token in player.GetHand())
            {
                value += token.Value();
            }
            return value;
        }
    }
}
