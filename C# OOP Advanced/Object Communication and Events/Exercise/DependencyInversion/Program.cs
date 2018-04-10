using DependencyInversion.Contracts;
using DependencyInversion.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new PrimitiveCalculator(GenerateStrategyMap());

            var input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                if (input.StartsWith("mode"))
                {
                    var strategy = input.Split()[1][0];
                    calculator.ChangeStrategy(strategy);
                }

                else
                {
                    var numbers = input.Split().Select(int.Parse).ToArray();

                    var result = calculator.PerformCalculation(numbers[0], numbers[1]);
                    Console.WriteLine(result);
                }
            }
        }

        private static Dictionary<char, IStrategy> GenerateStrategyMap()
        {
            var map = new Dictionary<char, IStrategy>
            {
                { '+', new AdditionStrategy()},
                { '-', new SubtractionStrategy()},
                { '*', new MultiplicationStrategy()},
                { '/',new DivisionStrategy()}
            };

            return map;
        }
    }
}
