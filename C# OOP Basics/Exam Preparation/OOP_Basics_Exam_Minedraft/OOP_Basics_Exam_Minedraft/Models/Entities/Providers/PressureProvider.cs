using System;
using System.Collections.Generic;
using System.Text;

public class PressureProvider : Provider
{
    private const double EnergyOutputIncrease = 1.5; //50%

    public PressureProvider(string id, double energyOutput) : base(id, energyOutput)
    {
        this.EnergyOutput *= EnergyOutputIncrease;
    }
}