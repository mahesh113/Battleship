namespace BattleShip
{
    public interface IPlayer
    {
        IPlayer opponent { get; set; }
        bool HasLost();
        bool Attack(int x, int y);
        bool HitFromOpponent(int x, int y);
        bool PlaceShipOnBoard(ShipPosition pos);
    }
}
