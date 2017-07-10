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
        var input = ReadLine();
        var didimonPattern = new Regex(@"[^a-zA-Z\-]+");
        var bojomonPattern = new Regex(@"[A-Za-z]+-[A-Za-z]+");

        var bojomonSTurn = false;

        while (true)
        {
            if (!bojomonSTurn && didimonPattern.IsMatch(input))
            {
                var match = didimonPattern.Match(input).Value;
                WriteLine(match);
                input = BuildNewString(input, match);
                bojomonSTurn = true;
            }
            else if (bojomonSTurn && bojomonPattern.IsMatch(input))
            {
                var match = bojomonPattern.Match(input).Value;
                WriteLine(match);
                input = BuildNewString(input, match);
                bojomonSTurn = false;
            }
            else break;
        }
    }

    private static string BuildNewString(string input, string match)
    {
        var sB = new StringBuilder();
        var startIndex = input.IndexOf(match) + match.Length;
        for (int i = startIndex; i < input.Length; i++)
            sB.Append(input[i]);

        return sB.ToString();
    }
}
