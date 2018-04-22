using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class AbstractHero : IHero
{
    private IInventory inventory;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name, long strength, long agility, long intelligence, long hitPoints, long damage)
    {
        this.Name = name;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.hitPoints = hitPoints;
        this.damage = damage;
        this.inventory = new HeroInventory();
    }

    public string Name { get; protected set; }

    public long Strength
    {
        get { return this.strength + this.inventory.TotalStrengthBonus; }
        protected set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.inventory.TotalAgilityBonus; }
        protected set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.inventory.TotalIntelligenceBonus; }
        protected set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.inventory.TotalHitPointsBonus; }
        protected set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.inventory.TotalDamageBonus; }
        protected set { this.damage = value; }
    }

    public long PrimaryStats => this.Strength + this.Agility + this.Intelligence;

    public long SecondaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    public IReadOnlyCollection<IItem> Items
    {
        get
        {
            var inventoryType = this.inventory.GetType();
            var inventoryFields = inventoryType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            var itemsField = inventoryFields.First(f => f.GetCustomAttributes(false).Any(a => a.GetType() == typeof(ItemAttribute)));

            var items = itemsField.GetValue(this.inventory) as Dictionary<string, IItem>;

            return items.Values.ToList().AsReadOnly();
        }
    }

    public void AddRecipe(IRecipe recipe) => this.inventory.AddRecipeItem(recipe);

    public void AddItem(IItem item) => this.inventory.AddCommonItem(item);

    public override string ToString()
    {
        var sB = new StringBuilder($"Hero: {this.Name}, Class: {this.GetType().Name}{Environment.NewLine}")
            .AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}")
            .AppendLine($"Strength: {this.Strength}")
            .AppendLine($"Agility: {this.Agility}")
            .AppendLine($"Intelligence: {this.Intelligence}")
            .Append("Items:");

        if (this.Items.Count == 0)
            sB.Append(" None");

        else
            sB.Append(Environment.NewLine + string.Join(Environment.NewLine, this.Items.Select(ItemOutput)));

        return sB.ToString();
    }

    private string ItemOutput(IItem item)
    {
        var sB = new StringBuilder();
        sB.AppendLine($"###Item: {item.Name}")
            .AppendLine($"###+{item.StrengthBonus} Strength")
            .AppendLine($"###+{item.AgilityBonus} Agility")
            .AppendLine($"###+{item.IntelligenceBonus} Intelligence")
            .AppendLine($"###+{item.HitPointsBonus} HitPoints")
            .Append($"###+{item.DamageBonus} Damage");

        return sB.ToString();
    }
}