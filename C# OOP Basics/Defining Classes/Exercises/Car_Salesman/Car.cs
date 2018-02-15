using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Salesman
{
    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public double Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine engine, double weight = -1, string color="n/a")
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public override string ToString()
        {
            return $"{Model}:\n" +
                $" {Engine.Model}:\n" +
                $"   Power: {Engine.Power}\n" +
                $"   Displacement: {(Engine.Displacement > -1 ? Engine.Displacement.ToString() : "n/a")}\n" +
                $"   Efficiency: {Engine.Efficiency}\n" +
                $" Weight: {(Weight > -1 ? Weight.ToString() : "n/a")}\n" +
                $" Color: {Color}";
        }
    }
}
