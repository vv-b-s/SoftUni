using System;

public abstract class Tyre : ITyre
{
    private const double InitialDegradation = 100;

    private double hardness;
    private double degradation;

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = InitialDegradation;
    }

    public abstract string Name { get; }

    public double Hardness
    {
        get => this.hardness;
        protected set => this.hardness = value;
    }

    public double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < this.MinimumDegradation)
                throw new FailedDriverException("Blown Tyre");

            else this.degradation = value;
        }
    }

    protected virtual double MinimumDegradation => 0;

    public virtual void DegradateTyre()
    {
        this.Degradation -= this.Hardness;
    }
}