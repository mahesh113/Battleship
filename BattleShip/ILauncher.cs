namespace BattleShip
{
    public interface ILauncher
    {
        IPlayer[] Initialize();
        bool AttackHandler(int x, int y, IPlayer opponent);
    }
}
