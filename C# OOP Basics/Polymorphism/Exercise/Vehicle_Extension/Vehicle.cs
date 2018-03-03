using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Extension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double littersPerKm, double tankCapacity)
        {
            this.FuelConsumption = littersPerKm;
            this.FuelQuantity = fuelQuantity <= tankCapacity ? fuelQuantity : 0;
            this.tankCapacity = tankCapacity;
        }

        /// <summary>
        /// The setter contains the logic of RefuelVehicle
        /// </summary>
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            private set
            {
                this.fuelQuantity = value;
            }
        }

        /// <summary>
        /// Measuered in liters per km
        /// </summary>
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public string DriveVehicle(double kilometers)
        {
            var fuelWasDecreased = DecreaseFuel(kilometers);

            var message = fuelWasDecreased ? $"{this.GetType().Name} travelled {kilometers} km" : $"{this.GetType().Name} needs refueling";

            return message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="litersOfFuel"></param>
        /// <param name="refuelLogic"></param>
        public void RefuelVehicle(double litersOfFuel)
        {
            if (litersOfFuel <= 0)
                throw new ArgumentException("Fuel must be a positive number");

            if (litersOfFuel + this.fuelQuantity > tankCapacity)
                throw new ArgumentException($"Cannot fit {litersOfFuel} fuel in the tank");

            else this.FuelQuantity += RefuelLogic(litersOfFuel);
        }

        /// <summary>
        /// Use this method to define how the tank behaves when it is refueled
        /// </summary>
        /// <param name="litersOfFuel"></param>
        /// <returns></returns>
        protected abstract double RefuelLogic(double litersOfFuel);

        public override string ToString() => $"{this.GetType().Name}: {fuelQuantity:F2}";

        private bool DecreaseFuel(double kilometers)
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
    }
}
