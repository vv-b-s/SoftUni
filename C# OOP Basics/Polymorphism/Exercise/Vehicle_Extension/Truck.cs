using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Extension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double littersPerKm, double tankCapacity) : base(fuelQuantity, littersPerKm, tankCapacity)
        {
            FuelConsumption += 1.6;
        }

        protected override double RefuelLogic(double litersOfFuel) => litersOfFuel * 0.95;
    }
}
