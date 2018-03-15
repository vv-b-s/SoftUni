using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PowerHardware : Hardware
{
    public PowerHardware(string name, int maximumCapacity, int maximumMemory) : base(name, maximumCapacity, maximumMemory)
    {
        this.MaximumCapacity -= (this.MaximumCapacity * 3) / 4;       // 75% Capacity decrease
        this.MaximumMemory += (this.MaximumMemory * 3) / 4;          // 75% Memory increase
    }
}