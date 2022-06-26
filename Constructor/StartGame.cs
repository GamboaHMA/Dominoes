using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;
using MyDomino;

namespace Constructor
{
    public class StartGame
    {
        public IStartGame<TokenDom, (int, int), List<bool>> startGame { get; set; }

        public StartGame(string item)
        {
            switch (item)
            {
                case "StartGameStandar":
                    startGame = new StartGameStandard();
                    break;
                case "StartGameHigherHand":
                    startGame = new StartGameHigherHand();
                    break;

                default:
                    startGame = new StartGameStandard();
                    break;
            }
        }
    }
}
