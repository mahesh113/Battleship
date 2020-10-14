using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
//using BattleShip.ShipPosition.AlignmentType;

namespace BattleShip
{
    class Player : IPlayer
    {
        public struct Cell 
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        class Ship
        {
            public List<Cell> _ship { get; set; }
        }
        int[,] Board;

        List<Ship> Ships; 
        public Player()
        {
            Board = new int[10, 10];
            Ships = new List<Ship>();
        }
        public IPlayer opponent { get; set; }

        public void Attack(int X, int Y)
        {
            bool ret = BattleShipAdmin.AttackHandler(X, Y, this);
        }

        public bool HasLost()
        {
            return Ships.Count == 0 ? true : false;
        }

        public bool PlaceShipOnBoard(ShipPosition pos)
        {
            bool ret = true;
            List<Cell> ship = new List<Cell>();
            if (pos.Align == ShipPosition.AlignmentType.Horizontal)
            {
                for (int i = 0; i < pos.Length && ret; i++)
                {
                    if (pos.X + i >= 10)
                    {
                        ret = false;
                    }
                    else
                    {
                        ship.Add(new Cell { X = pos.X + i, Y = pos.Y });
                    }
                }
            }
            else
            {
                for (int i = 0; i < pos.Length && ret; i++)
                {
                    if (pos.Y + i >= 10)
                    {
                        ret = false;
                    }
                    else
                    {
                        ship.Add(new Cell { X = pos.X, Y = pos.Y + i });
                    }
                }
            }
            if (ret)
            {
                Ships.Add(new Ship { _ship = ship });
            }
            return ret;
        }
        public bool HitFromOpponent(int x, int y)
        {

            Cell cell = new Cell { X = x, Y = y };
            Ship affectedShip = (from ship in Ships
                        //from cell in ship._ship
                    where ship._ship.Any(t => t.X == x & t.Y == y)
                    select ship).FirstOrDefault();
            if(affectedShip?._ship != null)
            {
                affectedShip._ship.Remove(cell);
                return true;
            }

            return false;
        }
    }
}
