using System;
using System.Collections.Generic;
using System.Text;

namespace Speed_Racing
{
    public class Car
    {
        public string Model { get; set; }
        public double Fuel { get; set; }
        public double FuelConsumptionKm { get; set; }
        public double TraveledDistance { get; set; }

        public Car(string model, double fuel, double consumptionPerKm)
        {
            Model = model;
            Fuel = fuel;
            FuelConsumptionKm = consumptionPerKm;
            TraveledDistance = 0;
        }

        public void Drive(double kilometers)
        {
            var neededFuel = FuelConsumptionKm * kilometers;

            if(Fuel>=neededFuel)
            {
                Fuel -= neededFuel;
                TraveledDistance += kilometers;
            }
            else Console.WriteLine("Insufficient fuel for the drive");
        }

        public override string ToString() => $"{Model} {Fuel:F2} {TraveledDistance}";
    }
}
