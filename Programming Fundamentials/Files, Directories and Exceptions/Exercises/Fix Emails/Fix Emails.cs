using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.IO;
using static System.Console;

class Program
{
    static void Main()
    {
        var lines = File.ReadLines(@"X:\Development\SoftUni\Files, Directories and Exceptions\Exercises\Fix Emails\input.txt");
        var NameEmail = new Dictionary<string, string>();

        int commandCount = 0;
        string prevKey = "";
        foreach(var userInput in lines)
        {
            if (userInput == "stop")
                break;
            if (commandCount % 2 == 0 && !NameEmail.Keys.Contains(userInput))
            {
                NameEmail[userInput] = "";
                prevKey = userInput;
            }
            if (commandCount % 2 != 0)
                NameEmail[prevKey] = userInput;

            commandCount++;
        }

        var filteredNameEmail = NameEmail.Where(k => !(k.Value.Contains(".us") || k.Value.Contains(".uk"))).ToDictionary(k => k.Key, k => k.Value);

        var sB = new StringBuilder();
        foreach (var resource in filteredNameEmail)
            sB.AppendLine(resource.Key + " -> " + resource.Value);

        File.WriteAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\Exercises\Fix Emails\output.txt", sB.ToString());
    }

}