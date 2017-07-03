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
        var skipTake = Regex.Split(ReadLine(), @"\s+").Select(n=>int.Parse(n)).ToArray();
        var pattern = new Regex($@"(?<=(\|\<.{AddVar($"{skipTake[0]}")}))[^|]{AddVar($"0,{skipTake[1]}")}");
        var text = ReadLine();
        var sentances = pattern.Matches(text).Cast<Match>().Select(m => m.Value).ToList();

        WriteLine(string.Join(", ", sentances));
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