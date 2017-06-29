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
        var searchedWord = ReadLine();
        var pattern = new Regex($@"($|([^\.\!\?])+)\b{searchedWord}\b((([^\.\!\?])+)|(?=[\.\!\?]))");
        var text = ReadLine();
        var sentances = pattern.Matches(text).Cast<Match>().Select(m => m.Value.Trim()).ToList();

        WriteLine(string.Join("\n", sentances));
    }

}