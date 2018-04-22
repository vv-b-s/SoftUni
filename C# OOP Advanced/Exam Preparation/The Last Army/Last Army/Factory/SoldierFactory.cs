using System;
using System.Collections.Generic;
using System.Linq;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        var soldierType = Type.GetType(soldierTypeName);
        var soldier = Activator.CreateInstance(soldierType, name, age, experience, endurance) as ISoldier;

        return soldier;
    }
}