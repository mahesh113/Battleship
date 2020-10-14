using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    public interface IPlayer
    {
        IPlayer opponent { get; set; }
        bool HasLost();
        void Attack(int x, int y);
        bool HitFromOpponent(int x, int y);
        bool PlaceShipOnBoard(ShipPosition pos);
    }
}
