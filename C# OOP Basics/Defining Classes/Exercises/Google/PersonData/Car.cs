using System;
using System.Collections.Generic;
using System.Text;

namespace Google.PersonData
{
    public class Car
    {
        public string Model { get; set; }
        public double Speed { get; set; }

        public Car() { }

        public Car(string model, double speed)
        {
            Model = model;
            Speed = speed;
        }

        public override string ToString() => $"{Model} {Speed}";
    }
}
