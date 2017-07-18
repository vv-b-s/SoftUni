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
        var matches = Regex.Matches(ReadLine(), @"(\s|^)(0x)?([0-9A-F]+)\b").Cast<Match>().Select(m=>m.Value.Trim()).ToArray();
        WriteLine(string.Join(" ", matches));
    }

}