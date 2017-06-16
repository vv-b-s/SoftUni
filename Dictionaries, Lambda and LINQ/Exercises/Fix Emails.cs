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
        var NameEmail = new Dictionary<string, string>();

        int commandCount = 0;
        string prevKey = "";
        while((userInput=ReadLine())!="stop")
        {
            if (commandCount % 2 == 0 && !NameEmail.Keys.Contains(userInput))
            {
                NameEmail[userInput] = "";
                prevKey = userInput;
            }
            if (commandCount % 2 != 0)
                NameEmail[prevKey] = userInput;

            commandCount++;
        }

        var filteredNameEmail = NameEmail.Where(k =>! (k.Value.Contains(".us") || k.Value.Contains(".uk"))).ToDictionary(k=>k.Key,k=>k.Value);

        foreach (var resource in filteredNameEmail)
            WriteLine(resource.Key + " -> " + resource.Value);
    }

}