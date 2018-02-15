using System;
using System.Collections.Generic;
using System.Text;

namespace Raw_Data.CarParts
{
    class Cargo
    {
        public double Weight { get; set; }
        public string Type { get; set; }

        public Cargo(double weight, string type)
        {
            Weight = weight;
            Type = type;
        }
    }
}
