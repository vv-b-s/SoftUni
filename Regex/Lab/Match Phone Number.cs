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
        var matches = Regex.Matches(ReadLine(), @"(^|\s)(\+359)( |-)2\3\d{3}\3\d{4}\b").Cast<Match>().Select(m=>m.Value.Trim()).ToArray();
        WriteLine(string.Join(", ", matches));
    }

}