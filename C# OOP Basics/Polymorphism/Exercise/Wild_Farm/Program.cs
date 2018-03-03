using System;
using System.Collections.Generic;
using System.Linq;
using Wild_Farm.Animals.Abstracts;

namespace Wild_Farm
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();

            var input = "";
            for (int i = 0; (input = Console.ReadLine()) != "End"; i++) 
            {
                var data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if(i%2==0)
                {
                    var animal = Factory.ManufactureAnimal(data);

                    Console.WriteLine(animal.GenerateHungrySound());
                    animals.Add(animal);
                }

                else
                {
                    try
                    {
                        var food = Factory.ManufactureFood(data);
                        animals.Last().TryToFeed(food);
                    }
                    catch (ArgumentException e) { Console.WriteLine(e.Message); }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, animals));
        }
    }
}
