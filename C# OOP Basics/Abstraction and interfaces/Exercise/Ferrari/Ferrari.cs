using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : IDrivableCar
    {
        public Ferrari(string driverName)
        {
            Model = "488-Spider";
            DriverName = driverName;
        }

        public string Model { get; set; }
        public string DriverName { get; set; }

        public string Breaks() => "Brakes!";

        public string Gas() => "Zadu6avam sA!";

        public override string ToString() => $"{Model}/{Breaks()}/{Gas()}/{DriverName}";
    }
}
