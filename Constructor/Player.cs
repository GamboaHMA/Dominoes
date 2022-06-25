using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;
using MyDomino;


namespace Constructor
{
    public class Player
    {
        public IPlayer<TokenDom, (int, int)> player { get; set; }

        public Player(string item)
        {
            switch (item)
            {
                case "PlayerRandom":
                    player = new PlayerRandom(new List<TokenDom>(), "PlayerRandom");
                    break;
                case "PlayerBotaGorda":
                    player = new PlayerBotaGorda(new List<TokenDom>(), "PlayerBotaGorda");
                    break;
                case "PlayerBotaGorda_Random":
                    player = new PlayerBotaGorda_Random(new List<TokenDom>(), "PlayerBotaGorda_Random");
                    break;

                default:
                    player = new PlayerRandom(new List<TokenDom>(), "PlayerRandom");
                    break;
            }
        }

        public Player()
        {

        }
    }

    public class PlayerList
    {
        public List<IPlayer<TokenDom, (int, int)>> players { get; set; }

        public PlayerList()
        {
            players = new List<IPlayer<TokenDom, (int, int)>>();
        }
    }
}
