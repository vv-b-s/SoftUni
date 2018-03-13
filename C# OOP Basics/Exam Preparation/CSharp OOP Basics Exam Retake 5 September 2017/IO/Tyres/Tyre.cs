using System;
using System.Collections.Generic;
using System.Text;

public abstract class Tyre : ITyre
{
    private double hardness;
    private double degradation;
    private string name;

    protected Tyre(double hardness)
    {
        this.Degradation = 100;
        this.Hardness = hardness;
    }

    public string Name
    {
        get => this.name;
        protected set => this.name = value;
    }

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
            if (value < BlowUpLimit)
                throw new ArgumentException("Blown Tyre");

            else this.degradation = value;
        }
    }

    protected virtual int BlowUpLimit => 0;

    public virtual void ReduceDegradation() => this.Degradation -= this.Hardness;
}