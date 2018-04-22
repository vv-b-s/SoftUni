using System;

public abstract class Provider : IProvider
{
    private const int InitialDurability = 1000;
    private const int DurabilityLossPerDay = 100;

    private double durability;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public double EnergyOutput { get; protected set; }

    public int ID { get; protected set; }

    public virtual double Durability
    {
        get => this.durability;
        protected set
        {
            if (value < 0)
                throw new InvalidOperationException("Provider is broken!");

            else this.durability = value;
        }
    }

    public void Broke()
    {
        this.Durability -= DurabilityLossPerDay;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        return  $"{this.GetType().FullName}{Environment.NewLine}Durability: {this.Durability}";
    }
}