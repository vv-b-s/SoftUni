using System.Collections.Generic;
using System.Text;

public class SpecialForce : Soldier
{
    private const double OverallSkillMiltiplier = 3.5;

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    public override double OverallSkill => base.OverallSkill * OverallSkillMiltiplier;

    public override IReadOnlyList<string> WeaponsAllowed => new List<string>
    {
        typeof(Gun).Name,
        typeof(AutomaticMachine).Name,
        typeof(MachineGun).Name,
        typeof(RPG).Name,
        typeof(Helmet).Name,
        typeof(Knife).Name,
        typeof(NightVision).Name
    };

    public override void Regenerate()
    {
        this.Endurance = 30 + this.Age;
    }
}