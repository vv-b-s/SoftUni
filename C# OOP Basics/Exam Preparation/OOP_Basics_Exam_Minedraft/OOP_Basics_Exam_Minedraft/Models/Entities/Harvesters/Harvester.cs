using System;
using System.Collections.Generic;
using System.Text;

public abstract class Harvester : IdentifiableObject, IHarvester
{
    private const int MaxEnergyRequirement = 20000;

    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement):base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }



    public double OreOutput
    {
        get => this.oreOutput;
        protected set
        {
            if (value < 0)
                throw new InvalidVariableException("Harvester",nameof(OreOutput));

            else this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set
        {
            if (value < 0 || value > MaxEnergyRequirement)
                throw new InvalidVariableException("Harvester",nameof(EnergyRequirement));

            else this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        var harvesterClassName = this.GetType().Name;

        //Represents the name of the harvester class without "Harvester" in it
        var harvesterType = this.GetType().Name.Substring(0, harvesterClassName.LastIndexOf("Harvester"));

        var text = $"{harvesterType} Harvester - {this.Id}{Environment.NewLine}" +
            $"Ore Output: {this.OreOutput}{Environment.NewLine}" +
            $"Energy Requirement: {this.energyRequirement}";
            
        return text;
    }
}
