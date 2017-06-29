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
        var matcher = new Regex(@"\b[A-Z][a-z]+\b \b[A-Z][a-z]+\b");
        var text = ReadLine();
        var matches = matcher.Matches(text);
        foreach (Match match in matches)
            Write(match.Value + " ");
        WriteLine();
    }

}