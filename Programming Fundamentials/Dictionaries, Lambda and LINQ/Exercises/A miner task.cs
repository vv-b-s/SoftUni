using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        string userInput;
        var resources = new Dictionary<string, double>();

        int commandCount = 0;
        string prevKey = "";
        while((userInput=ReadLine())!="stop")
        {
            if (commandCount % 2 == 0 && !resources.Keys.Contains(userInput))
            {
                resources[userInput] = 0;
                prevKey = userInput;
            }
            if (commandCount % 2 != 0)
                resources[prevKey] += double.Parse(userInput);

            commandCount++;
        }

        foreach (var resource in resources)
            WriteLine(resource.Key + " -> " + resource.Value);
    }
}