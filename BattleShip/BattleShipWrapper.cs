namespace BattleShip
{
    public class BattleShipWrapper: ILauncher
    {
        public IPlayer[] Initialize()
        {
            return BattleShipAdmin.Initialize();
        }
        public bool AttackHandler(int x, int y, IPlayer opponent)
        {
            return BattleShipAdmin.AttackHandler(x, y, opponent);
        }
    }
}
