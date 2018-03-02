using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public interface IDrivableCar
    {
        string Model { get; set; }
        string DriverName { get; set; }

        string Breaks();
        string Gas();
    }
}
