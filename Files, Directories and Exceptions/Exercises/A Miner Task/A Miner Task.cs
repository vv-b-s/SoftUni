using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;
using System.IO;

class Program
{
    static void Main()
    {
        var lines = File.ReadAllLines(@"X:\Development\SoftUni\Files, Directories and Exceptions\Exercises\A Miner Task\input.txt");
        var resources = new Dictionary<string, double>();

        int commandCount = 0;
        string prevKey = "";

        foreach (var userInput in lines)
        {
            if (userInput == "stop")
                break;
            if (commandCount % 2 == 0 && !resources.Keys.Contains(userInput))
            {
                resources[userInput] = 0;
                prevKey = userInput;
            }
            if (commandCount % 2 != 0)
                resources[prevKey] += double.Parse(userInput);

            commandCount++;

        }
        var sB = new StringBuilder();
        foreach (var resource in resources)
            sB.AppendLine(resource.Key + " -> " + resource.Value);

        File.WriteAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\Exercises\A Miner Task\output.txt", sB.ToString());
    }
}