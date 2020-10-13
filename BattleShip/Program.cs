using System;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            ILauncher game = new BattleShipAdmin();
            IPlayer[] players =  game.Initialize();
        }
    }
}
