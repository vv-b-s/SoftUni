using System;
using System.Collections.Generic;
using System.Text;

public class HammerHarvester : Harvester
{
    private const double OreOutputIncrease = 3; // 200%
    private const double EnergyRequirementIncrease = 2;   //100%

    public HammerHarvester(string id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput *= OreOutputIncrease;
        this.EnergyRequirement *= EnergyRequirementIncrease;
    }
}