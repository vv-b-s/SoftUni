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
        var input = ReadLine().ToUpper();
        var sequences = Regex.Matches(input, @"[^\d]*\d+").Cast<Match>().Select(m => m.Value).ToList();

        var sB = new StringBuilder();
        foreach (var sequence in sequences)
        {
            var timesRepeated = int.Parse(Regex.Match(sequence, @"\d+").Value);
            var seq = Regex.Match(sequence, @"[^\d]*").Value;
            for (int i = 0; i < timesRepeated; i++)
                sB.Append(seq);
        }

        var uniqueLetters = sB.ToString().Distinct().Where(c => !char.IsDigit(c)).Count();

        WriteLine($"Unique symbols used: {uniqueLetters}\n" +
            $"{sB}");

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