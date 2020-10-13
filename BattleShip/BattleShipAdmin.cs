using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    class BattleShipAdmin : ILauncher
    {

        Dictionary<IPlayer, IPlayer> PlayersMapping = new Dictionary<IPlayer, IPlayer>();
        public IPlayer[] Initialize()
        {
            IPlayer[] players = new Player[2];
            PlayersMapping.Add(players[0], players[1]);
            PlayersMapping.Add(players[0], players[1]);

            return players;
        }
    }
}
