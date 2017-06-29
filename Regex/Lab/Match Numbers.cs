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
        var pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";
        var text = ReadLine();
        var matches = Regex.Matches(text,pattern).Cast<Match>().Select(m=>m.Value).ToList();

        WriteLine(string.Join(" ", matches));
    }

}