using System;
using static System.Console;

class Program
{
    static void Main()
    {
        string[] Game = { "OutFall 4", "CS: OG", "Zplinter Zell", "Honored 2", "RoverWatch", "RoverWatch Origins Edition" };
        double[] Price = { 39.99, 15.99, 19.99, 59.99, 29.99, 39.99 };

        double startBalance = double.Parse(ReadLine());
        double currentBalance = startBalance;
        string userInput = "";
        bool outOfMoney = currentBalance <= 0;

        while ((userInput = ReadLine()).ToLower() != "game time")
        {
            for (int i = 0; i < Game.Length; i++)
            {
                if (userInput.ToLower() == Game[i].ToLower() && currentBalance >= Price[i])
                {
                    WriteLine($"Bought {Game[i]}");
                    currentBalance -= Price[i];
                    outOfMoney = currentBalance <= 0;
                    break;
                }
                else if (userInput.ToLower() == Game[i].ToLower() && (currentBalance < Price[i] || currentBalance <= 0))
                {
                    WriteLine(currentBalance < Price[i] && currentBalance > 0 ?
                        "Too Expensive" : "Out of money!");
                    outOfMoney = currentBalance <= 0;
                    break;
                }
                else if (i == Game.Length - 1 && userInput.ToLower() != Game[i].ToLower())
                    WriteLine("Not Found");
            }
        }

        WriteLine(outOfMoney ? "Out of money!" : $"Total spent: ${startBalance - currentBalance:F2}. Remaining: ${currentBalance:F2}");
    }
}
