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
        var str = ReadLine();
        int strength = 0;

        var strings = Regex.Matches(str, "[^>]+").Cast<Match>().Select(m => m.Value).ToList();

        for(int i=1;i<strings.Count;i++)
        {
            var strengthAdd = Regex.Match(strings[i],@"\d+").Value;
            strength += int.Parse(strengthAdd);

            var matchToRemove = Regex.Match(strings[i],$@".{AddVar($"0,{strength}")}").Value;
            strength -= matchToRemove.Length;

            strings[i] = Regex.Replace(strings[i], matchToRemove, "");
        }

        
        WriteLine(string.Join(">",strings));
    }

    static string AddVar(string value)
    {
        var sB = new StringBuilder();
        sB.Append('{');
        sB.Append(value);
        sB.Append('}');
        return sB.ToString();
    }

}