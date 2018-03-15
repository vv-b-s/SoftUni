using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LightSoftware : Software
{
    public LightSoftware(string name, int capacityConsumption, int memoryConsumption) : base(name, capacityConsumption, memoryConsumption)
    {
        this.CapacityConsumption += (this.CapacityConsumption * 1) / 2;        //50% increase
        this.MemoryConsumption -= (this.MemoryConsumption * 1) / 2;           //50% decrease
    }
}
