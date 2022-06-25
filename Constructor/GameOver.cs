using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;
using MyDomino;

namespace Constructor
{
    public class GameOver
    {
        public IGameOver<TokenDom, (int, int)> gameOver { get; set; }

        public GameOver(string item)
        {
            switch (item)
            {
                case "GameOverStandar":
                    gameOver = new GameOverStandard();
                    break;
                case "GameOverPass":
                    gameOver = new GameOverPass();
                    break;

                default:
                    gameOver = new GameOverStandard();
                    break;
            }
        }
    }
}
