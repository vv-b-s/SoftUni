using System;
using System.Collections.Generic;
using System.Text;

public class Cleric : Character, IHealable
{
    public Cleric(string name, Faction faction) :
        base(name, 50, 25, 40, new Backpack(), faction) { }

    public void Heal(Character character)
    {
        this.EnsureAlive();
        character.EnsureAlive();

        if (character.Faction != this.Faction)
            throw new InvalidOperationException("Cannot heal enemy character!");

        character.IncreaseHealth(this.AbilityPoints);
    }

    protected override double RestHealMultiplier => 0.5;
}