using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WareHouse : IWareHouse
{
    private Dictionary<string, IList<IAmmunition>> ammunitions;

    public WareHouse()
    {
        this.ammunitions = new Dictionary<string, IList<IAmmunition>>();
    }

    public IReadOnlyDictionary<string, IList<IAmmunition>> Ammunitions => this.ammunitions;

    public void AddAmmunitions(IAmmunition ammunition)
    {
        if (!this.ammunitions.ContainsKey(ammunition.Name))
            this.ammunitions[ammunition.Name] = new List<IAmmunition>();

        this.ammunitions[ammunition.Name].Add(ammunition);
    }

    public void EquipArmy(IArmy army)
    {
        var weaponsToRemove = new List<IAmmunition>();
        var weaponsToEquip = new List<IAmmunition>();
        foreach(var soldier in army.Soldiers.Cast<Soldier>())
        {
            foreach(var weapon in soldier.WeaponsAllowed)
            {
                if (!soldier.Weapons.ContainsKey(weapon))
                {
                    var takenWeapon = TryGetNewWeaponFromAmmunitions(weapon);

                    if (takenWeapon != null)
                        soldier.Weapons[weapon] = takenWeapon;  
                }

                else if (soldier.Weapons.ContainsKey(weapon) && soldier.Weapons[weapon].WearLevel <= 0)
                {                    
                    var takenWeapon = TryGetNewWeaponFromAmmunitions(weapon);

                    if(takenWeapon!=null)
                    {
                        soldier.Weapons.Remove(weapon);
                        soldier.Weapons[weapon] = takenWeapon;
                    }
                }
            }
        }
    }

    public void RemoveAmmunition(IAmmunition ammunition)
    {
        if (this.ammunitions.ContainsKey(ammunition.Name))
            this.ammunitions[ammunition.Name].Remove(ammunition);
    }

    private IAmmunition TryGetNewWeaponFromAmmunitions(string weapon)
    {
        if (this.ammunitions.ContainsKey(weapon) && this.ammunitions[weapon].Count > 0)
        {
            var ammunition = this.ammunitions[weapon].First();
            RemoveAmmunition(ammunition);

            return ammunition;
        }

        return null;
    }
}