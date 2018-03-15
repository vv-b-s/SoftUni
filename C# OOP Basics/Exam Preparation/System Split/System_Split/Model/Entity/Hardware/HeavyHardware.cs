using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HeavyHardware : Hardware
{
    public HeavyHardware(string name, int maximumCapacity, int maximumMemory) : base(name, maximumCapacity, maximumMemory)
    {
        this.MaximumMemory -= this.MaximumMemory / 4;         //25% decrease
        this.MaximumCapacity *= 2;                           // 100% increase
    }
}