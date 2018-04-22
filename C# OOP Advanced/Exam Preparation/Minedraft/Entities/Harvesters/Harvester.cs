using System;

public abstract class Harvester : IHarvester
{
    private const int InitialDurability = 1000;
    private const int DurabilityLossOnBroke = 100;

    private double oreOutput;
    private double energyRequirement;
    private double durability;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int ID { get; protected set; }

    public double OreOutput
    {
        get => this.oreOutput;
        protected set => this.oreOutput = value;
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set => this.energyRequirement = value;
    }

    public virtual double Durability
    {
        get => this.durability;
        protected set
        {
            if (value < 0)
                throw new InvalidOperationException("Harvester is broken");

            else this.durability = value;
        }
    }

    public void Broke()
    {
        this.Durability -= DurabilityLossOnBroke;
    }

    public double Produce()
    {
        return this.oreOutput;
    }

    public override string ToString()
    {
        return $"{this.GetType().FullName}{Environment.NewLine}Durability: {this.Durability}";
    }
}