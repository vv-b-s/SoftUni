using Pizza_Calories.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizza_Calories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaData = ReadData(Console.ReadLine());
                var doughData = ReadData(Console.ReadLine());

                var pizza = new Pizza(name: pizzaData[0]);
                var dough = new Dough(doughType: doughData[0], addition: doughData[1], weight: double.Parse(doughData[2]));

                pizza.Dough = dough;

                var input = "";
                while ((input = Console.ReadLine()) != "END")
                {
                    var toppingData = ReadData(input);

                    pizza.AddTopping(new Topping(toppingData[0], double.Parse(toppingData[1])));
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        /// <summary>
        /// Read the data without the first item which the user knows what type it is
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string[] ReadData(string text) => text.Split().Skip(1).ToArray();
    }
}
