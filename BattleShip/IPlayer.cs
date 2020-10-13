using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    public interface IPlayer
    {
        IPlayer opponent { get; set; }
        bool HasLost();
        void Attack();
        void PlaceShipOnBoard(int x, int y);
    }
}
