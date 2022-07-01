using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace MyDomino
{
    public class StartGame: IStartGame<TokenDom, (int, int), bool[]>
    {
        public IBoard<TokenDom, (int, int)> InitializateBoard(IBoard<TokenDom, (int, int)> board)
        {
            board = new Board(new List<TokenDom>(), (-1, -1));
            return board;
        }

        public void PlayerToMove(IPlayer<TokenDom, (int, int)>[] players, ITurnsPlayers<bool[]> turn)
        {
            bool win = false;
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].GetWinner()) { turn.GetTurnsPlayers()[i] = true; win = true; break; };
            }

            if (!win)
            {
                Random random = new Random();
                int random_ = random.Next(turn.GetTurnsPlayers().Length);
                turn.GetTurnsPlayers()[random_] = true;
            }
        }
    }
}
