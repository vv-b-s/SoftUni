using System;
using static System.Console;

class Program
{
    static void Main()
    {
        double statrtBudget = double.Parse(ReadLine());
        double budget = statrtBudget;
        int numOfItems = int.Parse(ReadLine());

        for(int i=0;i<numOfItems;i++)
        {
            string itemName = ReadLine();
            double itemPrice = double.Parse(ReadLine());
            int ammount = int.Parse(ReadLine());
            double endPrice = ammount*itemPrice;
            WriteLine($"Adding {ammount} {(ammount==1? itemName:itemName+'s')} to cart.");
            budget -= endPrice;
        }

        WriteLine($"Subtotal: ${Math.Abs(statrtBudget - budget):f2}\n" +
            (budget < 0 ? $"Not enough. We need ${Math.Abs(budget):f2} more." :
            $"Money left: ${budget:f2}"));
    }
}
