using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Extension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double littersPerKm, double tankCapacity) : base(fuelQuantity, littersPerKm, tankCapacity)
        {
            FuelConsumption += 1.4;
        }

        /// <summary>
        /// Exceptional method to alter the fuel consumption when the bus is empty
        /// </summary>
        /// <param name="kilometers"></param>
        /// <returns></returns>
        public string DriveEmpty(double kilometers)
        {
            FuelConsumption -= 1.4;
            var result = DriveVehicle(kilometers);
            FuelConsumption += 1.4;

            return result;
        }

        protected override double RefuelLogic(double litersOfFuel) => litersOfFuel;
    }
}
