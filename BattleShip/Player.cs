using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
//using BattleShip.ShipPosition.AlignmentType;

namespace BattleShip
{
    public class Player : IPlayer
    {
        public struct Cell
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        class Ship
        {
            public List<Cell> _deck { get; set; }
        }
        int[,] Board;

        List<Ship> Ships;

        private bool Validate (ShipPosition pos) =>  pos.X < 0 || pos.Y < 0 || pos.Y > 9 || pos.X > 9 || pos.Length > 9 || pos.Length < 1;
        public Player()
        {
            Board = new int[10, 10];
            Ships = new List<Ship>();
        }
        public IPlayer opponent { get; set; }

        public void Attack(int X, int Y)
        {
            // Code for no ship initialized
            bool ret = BattleShipAdmin.AttackHandler(X, Y, this);
        }

        public bool HasLost()
        {
            return Ships.Count == 0 ? true : false;
        }

        public bool PlaceShipOnBoard(ShipPosition pos)
        {
            if (Validate(pos))
                return false;

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
                Ships.Add(new Ship { _deck = ship });
            }
            return ret;
        }
        public bool HitFromOpponent(int x, int y)
        {

            Cell cell = new Cell { X = x, Y = y };
            Ship affectedShip = (from ship in Ships
                        //from cell in ship._ship
                    where ship._deck.Any(t => t.X == x & t.Y == y)
                    select ship).FirstOrDefault();
            if(affectedShip?._deck != null)
            {
                affectedShip._deck.Remove(cell);
                if(affectedShip._deck.Count == 0)
                {
                    Ships.Remove(affectedShip);
                }
                return true;
            }

            return false;
        }
    }
}
