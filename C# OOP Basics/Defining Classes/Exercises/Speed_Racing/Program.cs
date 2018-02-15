using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfCars = int.Parse(ReadLine());
            var modelsCars = new Dictionary<string, Car>();

            while(numberOfCars-->0)
            {
                var data = ReadLine().Split();
                var model = data[0];
                var fuel = double.Parse(data[1]);
                var consumotion = double.Parse(data[2]);

                modelsCars[model] = new Car(model, fuel, consumotion);
            }

            var input = "";
            while((input=ReadLine())!="End")
            {
                var data = input.Split().Skip(1).ToArray();
                var model = data[0];
                var distance = double.Parse(data[1]);

                modelsCars[model].Drive(distance);
            }

            WriteLine(string.Join("\n", modelsCars.Values));
        }
    }
}
