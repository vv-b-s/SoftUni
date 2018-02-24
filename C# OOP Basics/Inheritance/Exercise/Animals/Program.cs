using System;
using System.Collections.Generic;

namespace Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();

            var firstLine = "";
            while((firstLine = Console.ReadLine())!= "Beast!")
            {
                try
                {
                    var secondLine = Console.ReadLine();

                    var animal = AnimalFactory.GenerateAnimal(firstLine, secondLine.Split());
                    animals.Add(animal);
                }
                catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
            }

            Console.WriteLine(string.Join("\n", animals));
        }
    }
}
