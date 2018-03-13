using System;
using System.Collections.Generic;
using System.Text;

public interface IHarvester : IIdentifiable
{
    double OreOutput { get; }
    double EnergyRequirement { get; }
}