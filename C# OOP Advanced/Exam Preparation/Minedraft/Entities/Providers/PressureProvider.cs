using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PressureProvider : Provider
{
    private const double InitialDurabilityDecrease = 300;
    private const double InitialOutputMultiplier = 2;

    public PressureProvider(int id, double energyOutput) : base(id, energyOutput)
    {
        this.Durability -= InitialDurabilityDecrease;
        this.EnergyOutput *= InitialOutputMultiplier;
    }
}