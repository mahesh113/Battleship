
using Align = BattleShip.ShipPosition.AlignmentType;
namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayer[] players = BattleShipAdmin.Initialize();

            IPlayer p1 = players[0];
            IPlayer p2 = players[1];

            p1.PlaceShipOnBoard(new ShipPosition { Align = Align.Horizontal, X = 0, Y = 0, Length = 4 });
            p1.PlaceShipOnBoard(new ShipPosition { Align = Align.Vertical, X = 5, Y = 8, Length = 2 });


            p2.PlaceShipOnBoard(new ShipPosition { Align = Align.Horizontal, X = 2, Y = 3, Length = 4 });
            p2.PlaceShipOnBoard(new ShipPosition { Align = Align.Vertical, X = 5, Y = 5, Length = 3 });

            p2.Attack(0, 0);
            p2.Attack(0, 1);


            p1.Attack(4, 4);
            p1.Attack(4, 3);

            p2.Attack(3, 0);
            p2.Attack(2, 0);


            p1.Attack(3, 3);
            p1.Attack(2, 3);

            p2.Attack(1, 0);
            p2.Attack(5, 9);

            p1.Attack(5, 3);
            p1.Attack(5, 7);

            p2.Attack(5, 7);
            p2.Attack(5, 8);

            bool ret = p1.HasLost();
            ret = p2.HasLost();
        }
    }
}
