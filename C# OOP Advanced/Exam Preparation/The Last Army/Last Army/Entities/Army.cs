using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Army : IArmy
{
    private List<ISoldier> soldiers;
    private IWareHouse wareHouse;

    public Army(IWareHouse wareHouse)
    {
        this.wareHouse = wareHouse;

        this.soldiers = new List<ISoldier>();
    }

    public IReadOnlyList<ISoldier> Soldiers => this.soldiers.AsReadOnly();

    public void AddSoldier(ISoldier soldier)
    {
        if (!SoldierCanJoinTeam(soldier))
            throw new InvalidOperationException(string.Format(OutputMessages.UnableToRegisterSoldier, soldier.GetType().Name, soldier.Name));

        else
        {
            this.soldiers.Add(soldier);
            this.wareHouse.EquipArmy(this);
        }
    }

    public void RegenerateTeam(string soldierType)
    {
        var neededType = Type.GetType(soldierType);

        var soldiersToRegenerate = this.soldiers.
            Where(s => s.GetType() == neededType);

        foreach (var soldier in soldiersToRegenerate)
            soldier.Regenerate();
    }

    private bool SoldierCanJoinTeam(ISoldier soldier)
    {
        var soldierClass = soldier as Soldier;

        foreach (var weapon in soldierClass.WeaponsAllowed)
        {
            if (!this.wareHouse.Ammunitions.ContainsKey(weapon) || this.wareHouse.Ammunitions[weapon].Count == 0)
                return false;
        }

        return true;
    }
}