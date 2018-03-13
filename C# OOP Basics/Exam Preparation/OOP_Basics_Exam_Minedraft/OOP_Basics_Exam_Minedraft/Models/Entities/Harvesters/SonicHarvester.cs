using System;
using System.Collections.Generic;
using System.Text;

public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement /= this.SonicFactor;
    }

    public int SonicFactor
    {
        get => this.sonicFactor;
        private set
        {
            if (value < 1 || value > 10)
               throw new InvalidVariableException("Harvester",nameof(OreOutput));

            this.sonicFactor = value;
        }
    }
}