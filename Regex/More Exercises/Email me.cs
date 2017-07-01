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
        var email = Regex.Matches(ReadLine(), "[^@]+").Cast<Match>().Select(m => m.Value).ToList();
        var substractionOfTwoSides = email[0].Sum(e => e)-email[1].Sum(e=>e);
        WriteLine(substractionOfTwoSides > -1 ?
            "Call her!" :
            "She is not the one.");
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