using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const int MaximumEndurance = 100;

    private IDictionary<string, IAmmunition> weapons;

    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;

        this.weapons = new Dictionary<string, IAmmunition>();
    }

    public IDictionary<string, IAmmunition> Weapons => this.weapons;

    public abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public string Name { get; protected set; }

    public int Age { get; protected set; }

    public double Experience { get; protected set; }    

    public double Endurance
    {
        get => this.endurance;
        protected set => this.endurance = Math.Min(value, MaximumEndurance);
    }

    public virtual double OverallSkill => this.Age + this.Experience;

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        //IF the count null weapons is greater than zero
        bool hasAllEquipment = this.Weapons.Values.Count() == WeaponsAllowed.Count();

        if (!hasAllEquipment)
        {
            return false;
        }

        //If there is no weapon with wear level under zero
        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    //private void AmmunitionRevision(double missionWearLevelDecrement)
    //{
    //    IEnumerable<string> keys = this.Weapons.Keys.ToList();
    //    foreach (string weaponName in keys)
    //    {
    //        this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

    //        if (this.Weapons[weaponName].WearLevel <= 0)
    //        {
    //            this.Weapons[weaponName] = null;
    //        }
    //    }
    //}

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

    public abstract void Regenerate();

    public void CompleteMission(IMission mission)
    {
        foreach (var weapon in weapons)
            weapon.Value.DecreaseWearLevel(mission.WearLevelDecrement);

        this.Experience += mission.EnduranceRequired;
        this.Endurance -= mission.EnduranceRequired;
    }
}