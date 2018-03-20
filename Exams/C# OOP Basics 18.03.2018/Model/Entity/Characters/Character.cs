using System;
using System.Collections.Generic;
using System.Text;

public abstract class Character : ICharacter
{
    private string name;
    private double baseHealth;
    private double health;
    private double baseArmor;
    private double armor;
    private double abilityPoints;
    private Bag bag;
    private Faction faction;

    protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
    {
        this.Name = name;
        this.Health = this.BaseHealth = health;
        this.Armor = this.BaseArmor = armor;
        this.AbilityPoints = abilityPoints;
        this.Bag = bag;
        this.faction = faction;
    }

    public string Name
    {
        get => this.name;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value)|| string.IsNullOrEmpty(value))
                throw new ArgumentException("Name cannot be null or whitespace!");

            else this.name = value;
        }
    }

    public double BaseHealth
    {
        get => this.baseHealth;
        protected set => this.baseHealth = value;
    }

    public double Health
    {
        get => this.health;
        protected set
        {
            if (value <= 0)
            {
                this.IsAlive = false;
                this.health = 0;
            }
                
            else if (value > this.baseHealth)
                this.health = baseHealth;

           else this.health = value;
        }
    }

    public double BaseArmor
    {
        get => this.baseArmor;
        protected set => this.baseArmor = value;
    }

    public double Armor
    {
        get => this.armor;
        protected set
        {
            if (value < 0)
                this.armor = 0;

            else if (value > this.baseArmor)
                this.armor = baseArmor;

            else this.armor = value;
        }
    }

    public double AbilityPoints
    {
        get => this.abilityPoints;
        protected set => this.abilityPoints = value;
    }

    public Bag Bag
    {
        get
        {
            EnsureAlive();
            return this.bag;
        }
        protected set => this.bag = value;
    }

    public Faction Faction => this.faction;

    public bool IsAlive { get; protected set; } = true;

    protected virtual double RestHealMultiplier => 0.2;

    public void DecreaseHealth(double amount)
    {
        EnsureAlive();
        this.Health -= amount;
    }

    public void GiveCharacterItem(Item item, Character character)
    {
        EnsureAlive();

        character.ReceiveItem(item);
    }

    public void IncreaseHealth(double amount)
    {
        EnsureAlive();

        this.Health += amount;
    }

    public void ReceiveItem(Item item)
    {
        EnsureAlive();

        this.Bag.AddItem(item);
    }

    public void RepairArmor()
    {
        EnsureAlive();

        this.Armor = this.BaseArmor;
    }

    public void Rest()
    {
        EnsureAlive();

        this.Health += this.BaseHealth * this.RestHealMultiplier;
    }

    public void TakeDamage(double hitPoints)
    {
        EnsureAlive();

        if (this.Armor > 0)
        {
            var diff = this.Armor - hitPoints;
            this.Armor -= hitPoints;

            hitPoints = diff < 0 ? Math.Abs(diff) : 0;
        }

        if (hitPoints > 0)
            this.DecreaseHealth(hitPoints);
    }

    public void UseItem(Item item)
    {
        EnsureAlive();

        item.AffectCharacter(this);
    }

    public void UseItemOn(Item item, Character character)
    {
        EnsureAlive();

        character.UseItem(item);
    }

    public void EnsureAlive()
    {
        if (!this.IsAlive)
            throw new InvalidOperationException("Must be alive to perform this action!");
    }

    public override string ToString()
    {
        var output = $"{this.Name} - HP: {this.health}/{this.BaseHealth}, AP: {this.armor}/{this.baseArmor}, Status: {(this.IsAlive ? "Alive" : "Dead")}";
        return output;
    }
}