using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Program
{
    static void Main()
    {
        var broadcasts = new List<string>[] { new List<string>(), new List<string>() };
        var messages = new List<string>[] { new List<string>(), new List<string>() };

        string input;
        while ((input = ReadLine()) != "Hornet is Green")
        {
            var querries = Regex.Split(input, @"\s+<->\s+");
            if (querries.Length < 2)
                continue;

            if (Regex.IsMatch(querries[0], @"^\d+$") && Regex.IsMatch(querries[1], @"^[a-zA-Z0-9]+$"))
            {
                messages[0].Add(querries[0]);
                messages[1].Add(querries[1]);
            }
            else if (Regex.IsMatch(querries[0], @"^\D+$") && Regex.IsMatch(querries[1], @"^[a-zA-Z0-9]+$"))
            {
                broadcasts[0].Add(querries[0]);
                broadcasts[1].Add(querries[1]);
            }

        }

        messages[0] = messages[0].Select(m => new string(m.Reverse().ToArray())).ToList();

        WriteLine("Broadcasts:");
        if (broadcasts[0].Count > 0)
        {
            for (int i = 0; i < broadcasts[0].Count; i++)
            {
                var freg = new string(broadcasts[1][i].Select(c => char.IsLower(c) ? char.ToUpper(c) : char.ToLower(c)).ToArray());
                WriteLine($"{freg} -> {broadcasts[0][i]}");
            }
        }
        else WriteLine("None");

        WriteLine("Messages:");
        if (messages[0].Count > 0)
            for (int i = 0; i < messages[0].Count; i++)
                WriteLine($"{messages[0][i]} -> {messages[1][i]}");
        else WriteLine("None");
    }
}