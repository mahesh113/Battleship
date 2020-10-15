﻿using System;
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
        private int[,] Board;
        private const int BoardSquareOf = 10;
        private List<Ship> Ships;
        private BattleShipWrapper wrapper;

        private bool WrongPosition (ShipPosition pos) =>  pos==null || pos.X < 0 || pos.Y < 0 || pos.Y > 9 || pos.X > 9 || pos.Length > 10 || pos?.Length < 1;
        private bool ValidateCoordinates(int x, int y) => x >= 0 && x < 10 && y >= 0 && y < 10;
        public Player()
        {
            Board = new int[BoardSquareOf, BoardSquareOf];
            Ships = new List<Ship>();
            wrapper = new BattleShipWrapper();
        }
        public IPlayer opponent { get; set; }

        public bool Attack(int X, int Y)
        {
            if (!ValidateCoordinates(X, Y))
                return false;

            // Can't attack as no ship has been placed
            if (Ships.Count == 0)
                return false;

            return wrapper.AttackHandler(X, Y, opponent);
        }

        public bool HasLost()
        {
            return Ships.Count == 0 ? true : false;
        }

        public bool PlaceShipOnBoard(ShipPosition pos)
        {
            if (WrongPosition(pos))
                return false;

            bool ret = true;
            List<Cell> ship = new List<Cell>();
            if (pos.Align == ShipPosition.AlignmentType.Horizontal)
            {
                for (int i = 0; i < pos.Length && ret; i++)
                {
                    if (pos.X + i >= 10 || // Out of Bound
                            Board[pos.X + i, pos.Y] == 1) // Overlap
                    {
                        ret = false;
                    }
                    else
                    {
                        ship.Add(new Cell { X = pos.X + i, Y = pos.Y });
                        Board[pos.X + i, pos.Y] = 1;
                    }
                }
            }
            else
            {
                for (int i = 0; i < pos.Length && ret; i++)
                {
                    if (pos.Y + i >= 10 ||  // Out of Bound
                            Board[pos.X, pos.Y + i] == 1) // Overlap
                    {
                        ret = false;
                    }
                    else
                    {
                        ship.Add(new Cell { X = pos.X, Y = pos.Y + i });
                        Board[pos.X, pos.Y + i] = 1;
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
                Board[x, y] = 0;
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
