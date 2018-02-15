using Raw_Data.CarParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raw_Data
{
    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public List<Tire> Tires { get; set; }

        public bool IsFragile => Cargo.Type == "fragile" && Tires.Any(tire => tire.Pressure < 1);
        public bool IsFlamable => Cargo.Type == "flamable" && Engine.Power > 250;

        public Car(string model, string engineSpeed, string enginePower, string cargoWeight, string cargoType, string tire1Pressure, string tire1Age,
            string tire2Pressure, string tire2Age, string tire3Pressure, string tire3Age, string tire4Pressure, string tire4Age)
        {
            Model = model;

            Engine = new Engine(int.Parse(engineSpeed), int.Parse(enginePower));
            Cargo = new Cargo(double.Parse(cargoWeight), cargoType);

            Tires = new List<Tire>()
            {
                new Tire(double.Parse(tire1Pressure),double.Parse(tire1Age)),
                new Tire(double.Parse(tire2Pressure),double.Parse(tire2Age)),
                new Tire(double.Parse(tire3Pressure),double.Parse(tire3Age)),
                new Tire(double.Parse(tire4Pressure),double.Parse(tire4Age))
            };
        }

        public override string ToString() => Model;
    }
}
