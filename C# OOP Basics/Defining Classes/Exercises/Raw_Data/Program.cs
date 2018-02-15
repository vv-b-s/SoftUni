using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Raw_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();

            var numberOfCarsToAdd = int.Parse(ReadLine());

            while(numberOfCarsToAdd-->0)
            {
                var data = ReadLine().Split();
                cars.Add(new Car(data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8], data[9], data[10], data[11], data[12]));
            }

            var cargoModelToLookFor = ReadLine();
            if (cargoModelToLookFor == "fragile")
                WriteLine(string.Join("\n", cars.Where(c => c.IsFragile)));
            else WriteLine(string.Join("\n", cars.Where(c => c.IsFlamable)));
        }
    }
}
