
using Align = BattleShip.ShipPosition.AlignmentType;
namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            ILauncher game = new BattleShipAdmin();
            IPlayer[] players = game.Initialize();

            IPlayer p1 = players[0];
            IPlayer p2 = players[1];

            p1.PlaceShipOnBoard(new ShipPosition { Align = Align.Horizontal, X = 0, Y = 0, Length = 4 });
            p1.PlaceShipOnBoard(new ShipPosition { Align = Align.Vertical, X = 5, Y = 8, Length = 3 });


            p2.PlaceShipOnBoard(new ShipPosition { Align = Align.Horizontal, X = 2, Y = 3, Length = 4 });
            p2.PlaceShipOnBoard(new ShipPosition { Align = Align.Vertical, X = 5, Y = 5, Length = 3 });

            p2.Attack(0, 0);
            p2.Attack(0, 1);
        }
    }
}
