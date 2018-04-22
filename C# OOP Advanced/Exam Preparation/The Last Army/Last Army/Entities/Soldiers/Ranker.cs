using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ranker : Soldier
{
    private const double DefaultOverallSkillMultiplier = 1.5;

    public Ranker(string name, int age, double experience, double endurance) : base(name, age, experience, endurance)
    {
    }

    public override double OverallSkill => base.OverallSkill * DefaultOverallSkillMultiplier;

    public override IReadOnlyList<string> WeaponsAllowed => new List<string>
    {
        typeof(Gun).Name,
        typeof(AutomaticMachine).Name,
        typeof(Helmet).Name
    };

    public override void Regenerate()
    {
        this.Endurance += 10 + this.Age;
    }
}