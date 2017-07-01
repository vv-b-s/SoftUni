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
        var map = ReadLine();
        while(true)
        {
            var rawClue = ReadLine();
            var clue = Regex.Split(rawClue, @"\s+");
            var hideOut = Regex.Match(map, $@"\{clue[0]}{AddVar($"{clue[1]},")}").Value;
            int hideOutIndex=0;
            if(hideOut.Length>0)
            {
                hideOutIndex = map.IndexOf(hideOut);
                WriteLine($"Hideout found at index {hideOutIndex} and it is with size {hideOut.Length}!");
                break;
            }
        }
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