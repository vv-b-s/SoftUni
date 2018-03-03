using System;

namespace Vehicle_Extension
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = VehicleFactory.Manufacture(Console.ReadLine().Split());
            var truck = VehicleFactory.Manufacture(Console.ReadLine().Split());
            var bus = VehicleFactory.Manufacture(Console.ReadLine().Split());

            var numberOfQueries = int.Parse(Console.ReadLine());

            while(numberOfQueries-->0)
            {
                try
                {
                    var data = Console.ReadLine().Split();

                    var command = data[0].ToLower();
                    var typeOfVehicle = data[1].ToLower();
                    var quantityValue = double.Parse(data[2]);

                    switch (command)
                    {
                        case "drive":
                            if (typeOfVehicle == "car") Console.WriteLine(car.DriveVehicle(quantityValue));
                            else if (typeOfVehicle == "truck") Console.WriteLine(truck.DriveVehicle(quantityValue));
                            else if (typeOfVehicle == "bus") Console.WriteLine(bus.DriveVehicle(quantityValue));
                            break;

                        case "driveempty":
                            Console.WriteLine((bus as Bus).DriveEmpty(quantityValue));
                            break;

                        case "refuel":
                            if (typeOfVehicle == "car") car.RefuelVehicle(quantityValue);
                            else if (typeOfVehicle == "truck") truck.RefuelVehicle(quantityValue);
                            else if (typeOfVehicle == "bus") bus.RefuelVehicle(quantityValue);
                            break;
                    }
                }
                catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
            }

            Console.WriteLine(car + Environment.NewLine + truck + Environment.NewLine + bus);
        }
    }
}
