using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Extension
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double littersPerKm, double tankCapacity) : base(fuelQuantity, littersPerKm, tankCapacity)
        {
            FuelConsumption += 0.9;
        }

        protected override double RefuelLogic(double litersOfFuel) => litersOfFuel;
    }
}
