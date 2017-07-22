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
        var pattern = new Regex(@"(^|(?<=\s))[a-z0-9]+([\.\-_]?[a-z0-9]+)\@\w+([\.\-]?\w+)*\.\w+($|(?=(,| |\.)))");
        var text = ReadLine();
        var emails = pattern.Matches(text).Cast<Match>().Select(m => m.Value).ToList();

        WriteLine(string.Join("\n", emails));
    }

}