using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IDriver
{
    string Name { get; }
    double TotalTime { get; set; }
    Car Car { get;}
    double FuelConsumptionPerKm { get; }
    double Speed { get; }
}