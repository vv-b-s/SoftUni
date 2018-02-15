using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Salesman
{
    class Engine
    {
        public string Model { get; set; }
        public double Power { get; set; }
        public double Displacement { get; set; }
        public string Efficiency { get; set; }

        public Engine(string model, double power, double displacement = -1, string efficiency = "n/a")
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }
    }
}
