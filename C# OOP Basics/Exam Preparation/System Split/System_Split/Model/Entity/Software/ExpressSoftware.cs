using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ExpressSoftware : Software
{
    public ExpressSoftware(string name, int capacityConsumption, int memoryConsumption) : base(name, capacityConsumption, memoryConsumption)
    {
        this.MemoryConsumption *= 2; //100% increase
    }
}