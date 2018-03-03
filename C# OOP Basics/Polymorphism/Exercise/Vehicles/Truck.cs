using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double littersPerKm) : base(fuelQuantity, littersPerKm) { }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            set => base.FuelConsumption = value + 1.6;
        }

        public override string DriveVehicle(double kilometers)
        {
            var fuelWasDecreased = DecreaseFuel(kilometers);

            var message = fuelWasDecreased ? $"Truck travelled {kilometers} km" : "Truck needs refueling";

            return message;
        }

        public override void RefuelVehicle(double litersOfFuel) => FuelQuantity += litersOfFuel * 0.95;
    }
}
