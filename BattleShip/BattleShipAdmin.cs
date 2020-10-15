using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    public  class BattleShipAdmin 
    {
        const int NumOfPlayers = 2;
        //Dictionary<IPlayer, IPlayer> PlayersMapping = new Dictionary<IPlayer, IPlayer>();
        public static IPlayer[] Initialize()
        {
            IPlayer[] players = new Player[NumOfPlayers];
            for (int i = 0; i < NumOfPlayers; i++)
            {
                players[i] = new Player();
            }
            players[0].opponent = players[1];
            players[1].opponent = players[0];

            //PlayersMapping.Add(players[0], players[1]);
            //PlayersMapping.Add(players[1], players[0]);

            return players;
        }

        public static bool AttackHandler(int x, int y, IPlayer opponent)
        {
            return opponent.HitFromOpponent(x, y);
        }
    }
}
