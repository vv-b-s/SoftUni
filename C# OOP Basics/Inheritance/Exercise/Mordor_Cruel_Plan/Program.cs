using Mordor_Cruel_Plan.Foods;
using Mordor_Cruel_Plan.Moods;
using Mordor_Cruel_Plan.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mordor_Cruel_Plan
{
    class Program
    {
        static void Main(string[] args)
        {
            var foods = new List<Food>();
            var foodFactory = new Factory<Food>();

            var foodInput = Console.ReadLine().Split();
            foreach (var foodItem in foodInput)
                foods.Add(foodFactory.Manufacture(foodItem));

            var mood = new Factory<Mood>().Manufacture(foods);

            Console.WriteLine($"{foods.Sum(f => f.MoodPoints)}\n{mood}");
        }
    }
}
