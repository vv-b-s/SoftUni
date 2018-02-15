using System;
using System.Collections.Generic;
using System.Text;

namespace Raw_Data.CarParts
{
    class Tire
    {
        public double Pressure { get; set; }
        public double Age { get; set; }

        public Tire(double pressure, double age)
        {
            Pressure = pressure;
            Age = age;
        }
    }
}
