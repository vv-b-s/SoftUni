using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ISoftware
{
    string Name { get; }
    int CapacityConsumption { get; }
    int MemoryConsumption { get; }
}