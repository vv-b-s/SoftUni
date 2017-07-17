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
        var matches = Regex.Matches(ReadLine(), "[^|]+").Cast<Match>().Select(m => m.Value).ToList();

        var letters = new StringBuilder();
        foreach(var match in matches)
        {
            var totalSum = 0;
            foreach (var ch in match)
                totalSum += ch == '0' ? 3 : 5;

            var bonusFromZeroes = 0;
            var bonusFromOnes = 0;

            var zeroSequences = Regex.Matches(match, "0{2,}");
            foreach(Match zero in zeroSequences)
                bonusFromZeroes += zero.Length;
            
            var oneSequences = Regex.Matches(match, "1{2,}");
            foreach (Match one in oneSequences)
                bonusFromOnes += one.Length;

            totalSum += bonusFromOnes + bonusFromZeroes;

            letters.Append((char)totalSum);
        }

        WriteLine(letters);
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