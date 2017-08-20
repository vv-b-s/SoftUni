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
        var validTrains = new List<string>();
        string input;
        while ((input = ReadLine())!="Traincode!")
        {
            if (Regex.IsMatch(input, @"^(<\[[^a-zA-Z0-9]*\]\.)(\.\[[a-zA-Z0-9]*\]\.)*?$"))
                validTrains.Add(input);
        }
        WriteLine(string.Join("\n", validTrains));
    }
}
