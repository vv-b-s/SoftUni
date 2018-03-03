using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double littersPerKm) : base(fuelQuantity, littersPerKm) { }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;

            //It is summer so the car uses 0.9 liters more fuel
            set => base.FuelConsumption = value + 0.9;
        }

        public override string DriveVehicle(double kilometers)
        {
            var fuelWasDecreased = DecreaseFuel(kilometers);

            var message = fuelWasDecreased ? $"Car travelled {kilometers} km" : "Car needs refueling";

            return message;
        }

        public override void RefuelVehicle(double litersOfFuel) => FuelQuantity += litersOfFuel;
    }
}
