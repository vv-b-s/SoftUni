using System;
using static System.Console;

class Program
{
    static void Main()
    {
        int timesEating = int.Parse(ReadLine());
        int totalCalories = 0;
        for(int i=0;i<timesEating;i++)
        {
            string food = ReadLine().ToLower();
            switch (food)
            {
                case "cheese":
                    totalCalories += 500; break;
                case "tomato sauce":
                    totalCalories += 150; break;
                case "salami":
                    totalCalories += 600; break;
                case "pepper":
                    totalCalories += 50; break;
            }
        }
        WriteLine($"Total calories: {totalCalories}");
    }
}
