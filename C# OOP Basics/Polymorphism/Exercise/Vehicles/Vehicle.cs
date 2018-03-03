using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public Vehicle(double fuelQuantity, double littersPerKm)
        {
            this.FuelConsumption = littersPerKm;
            this.FuelQuantity = fuelQuantity;
        }

        /// <summary>
        /// The setter contains the logic of RefuelVehicle
        /// </summary>
        public virtual double FuelQuantity
        {
            get { return fuelQuantity; }
            protected set { fuelQuantity = value; }
        }

        /// <summary>
        /// Measuered in liters per km
        /// </summary>
        public virtual double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public abstract string DriveVehicle(double kilometers);
        public abstract void RefuelVehicle(double litersOfFuel);

        protected virtual bool DecreaseFuel(double kilometers)
        {
            var decreaseValue = kilometers * this.FuelConsumption;

            //Check if the vehicle can travel thet distance and decrease the fuel if possible
            if (this.FuelQuantity >= decreaseValue)
            {
                this.FuelQuantity -= decreaseValue;
                return true;
            }

            //Otherwise the car cannot travel anymore and no more fuel is decreased
            else return false;
        }

        public override string ToString() => $"{this.GetType().Name}: {fuelQuantity:F2}";
    }
}
