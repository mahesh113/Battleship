using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    class Player : IPlayer
    {
        public IPlayer opponent { get; set; }

        public void Attack()
        {
            throw new NotImplementedException();
        }

        public bool HasLost()
        {
            throw new NotImplementedException();
        }

        public void PlaceShipOnBoard(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
