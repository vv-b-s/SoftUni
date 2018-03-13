using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICar
{
    int Hp { get; }
    double FuelAmount { get; }
    Tyre Tyre { get; }
}
