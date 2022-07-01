using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace MyDomino
{
    public class MyDom
    {
        public IRules<TokenDom, (int, int)> DefineRules()
        {
            Rules rules = new Rules();
            return rules;
        }

        public ICreatingPlayers<TokenDom, (int, int)> CreatingPlayers()
        {
            CreatingPlayers creating = new CreatingPlayers();
            return creating;
        }

        public ITurnsPlayers<bool[]> TurnPlayers(IPlayer<TokenDom, (int, int)>[] players)
        {
            TurnOfPlayer turn = new TurnOfPlayer(players);
            return turn;
        }

        public IStartGame<TokenDom, (int, int), bool[]> StartGame()
        {
            StartGame startGame = new StartGame();
            return startGame;
        }
    }
}
