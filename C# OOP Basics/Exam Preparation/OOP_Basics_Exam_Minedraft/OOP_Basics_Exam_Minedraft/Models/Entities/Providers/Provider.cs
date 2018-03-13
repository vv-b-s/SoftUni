using System;
using System.Collections.Generic;
using System.Text;

public abstract class Provider : IdentifiableObject, IProvider
{
    private const double EnergyOutputLimit = 10_000;

    private double energyOutput;

    protected Provider(string id, double energyOutput):base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get => this.energyOutput;
        protected set
        {
            if (value < 0 || value > EnergyOutputLimit)
                throw new InvalidVariableException("Provider",nameof(EnergyOutput));

            else this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        var providerClassName = this.GetType().Name;

        //Represents the name of the class without "Provider" in it
        var type = providerClassName.Substring(0, providerClassName.LastIndexOf("Provider"));

        var text = $"{type} Provider - {this.Id}{Environment.NewLine}" +
            $"Energy Output: {this.energyOutput}";

        return text;
    }
}