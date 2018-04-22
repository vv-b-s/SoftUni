using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class AbstractItem : IItem
{
    protected AbstractItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus)
    {
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.HitPointsBonus = hitPointsBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.DamageBonus = damageBonus;
    }

    public string Name { get; protected set; }

    public long StrengthBonus { get; protected set; }

    public long AgilityBonus { get; protected set; }

    public long IntelligenceBonus { get; protected set; }

    public long HitPointsBonus { get; protected set; }

    public long DamageBonus { get; protected set; }
}
