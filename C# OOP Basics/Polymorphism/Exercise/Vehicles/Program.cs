using System;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = VehicleFactory.Manufacture(Console.ReadLine().Split());
            var truck = VehicleFactory.Manufacture(Console.ReadLine().Split());

            var numberOfQueries = int.Parse(Console.ReadLine());

            while(numberOfQueries-->0)
            {
                var data = Console.ReadLine().Split();

                var command = data[0].ToLower();
                var typeOfVehicle = data[1].ToLower();
                var quantityValue = double.Parse(data[2]);

                switch(command)
                {
                    case "drive":
                        if (typeOfVehicle == "car") Console.WriteLine(car.DriveVehicle(quantityValue));
                        else if (typeOfVehicle == "truck") Console.WriteLine(truck.DriveVehicle(quantityValue));
                        break;
                    case "refuel":
                        if (typeOfVehicle == "car") car.RefuelVehicle(quantityValue);
                        else if (typeOfVehicle == "truck") truck.RefuelVehicle(quantityValue);
                        break;
                }
            }

            Console.WriteLine(car+Environment.NewLine+truck);
        }
    }
}
