using System;
using System.Collections.Generic;
using static System.Console;

namespace Car_Salesman
{
    class Program
    {
        static void Main(string[] args)
        {
            var engines = new Dictionary<string, Engine>();

            var numberOfEngines = int.Parse(ReadLine());

            while(numberOfEngines-->0)
            {
                var engineData = ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                var engineModel = engineData[0];
                var enginePower = double.Parse(engineData[1]);

                if(engineData.Length==4)
                {
                    var engineDisplacement = double.Parse(engineData[2]);
                    var enginEfficiency = engineData[3];

                    engines[engineModel] = new Engine(engineModel, enginePower, engineDisplacement, enginEfficiency);
                }
                else if(engineData.Length==3)
                {
                    if (double.TryParse(engineData[2], out double engineDisplacement))
                        engines[engineModel] = new Engine(engineModel, enginePower, engineDisplacement);
                    else engines[engineModel] = new Engine(engineModel, enginePower, efficiency: engineData[2]);
                }
                else engines[engineModel] = new Engine(engineModel, enginePower);

            }

            var cars = new List<Car>();
            var numberOfCars = int.Parse(ReadLine());

            while(numberOfCars-->0)
            {
                var data = ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var carModel = data[0];
                var carEngine = engines[data[1]];

                if (data.Length==4)
                {
                    var carWeight = double.Parse(data[2]);
                    var carColor = data[3];

                    cars.Add(new Car(carModel, carEngine, carWeight, carColor));
                }
                else if(data.Length==3)
                {
                    if (double.TryParse(data[2], out double carWeight))
                        cars.Add(new Car(carModel, carEngine, carWeight));
                    else
                        cars.Add(new Car(carModel, carEngine, color: data[2]));
                }
                else cars.Add(new Car(carModel, carEngine));
            }

            WriteLine(string.Join("\n", cars));
        }
    }
}
