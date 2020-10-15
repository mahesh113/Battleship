using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    public interface ILauncher
    {
        IPlayer[] Initialize();
        bool AttackHandler(int x, int y, IPlayer opponent);
    }
}
