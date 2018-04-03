using System;
using System.Linq;

namespace TrafficLights
{
    class Program
    {
        static void Main(string[] args)
        {
            var trafficLights = Console.ReadLine()
                .Split()
                .Select(l => new TrafficLight(Enum.Parse<TrafficLight.Light>(l)))
                .ToArray();

            var timesOfChanges = int.Parse(Console.ReadLine());

            while (timesOfChanges-- > 0)
            {
                foreach (var trafficLight in trafficLights)
                {
                    trafficLight.ChangeLight();
                    Console.Write(trafficLight + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
