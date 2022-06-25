using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace MyDomino
{
    public class StartGameStandard: IStartGame<TokenDom, (int, int), List<bool>>
    {
        public IBoard<TokenDom, (int, int)> InitializateBoard(IBoard<TokenDom, (int, int)> board)
        {
            board = new BoardStandard();
            return board;
        }

        public void PlayerToMove(List<IPlayer<TokenDom, (int, int)>> players, ITurnsPlayers<TokenDom,(int, int),List<bool>> turn)
        {
            bool win = false;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].GetWinner()) { turn.GetTurnsPlayers()[i] = true; win = true; break; };
            }

            if (!win)
            {
                Random random = new Random();
                int random_ = random.Next(turn.GetTurnsPlayers().Count);
                turn.GetTurnsPlayers()[random_] = true;
            }
        }
    }
}
