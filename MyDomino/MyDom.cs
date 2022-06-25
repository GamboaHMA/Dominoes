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
            RulesStandard rules = new RulesStandard();
            return rules;
        }

        public ICreatingPlayers<TokenDom, (int, int)> CreatingPlayers()
        {
            CreatingPlayers creating = new CreatingPlayers();
            return creating;
        }

        public ITurnsPlayers<TokenDom,(int, int),List<bool>> TurnPlayers(List<IPlayer<TokenDom, (int, int)>> players)
        {
            TurnsPLayersStandard turn = new TurnsPLayersStandard();
            return turn;
        }

        public IStartGame<TokenDom, (int, int), List<bool>> StartGame()
        {
            StartGameStandard startGame = new StartGameStandard();
            return startGame;
        }
    }
}
