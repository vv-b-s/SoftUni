using System;
using System.Collections.Generic;
using System.Text;

public abstract class Item : IItem
{
    private int weight;

    protected Item(int weight)
    {
        this.Weight = weight;
    }

    public int Weight
    {
        get => this.weight;
        protected set => this.weight = value;
    }

    public virtual void AffectCharacter(Character character)
    {
        character.EnsureAlive();
    }
}