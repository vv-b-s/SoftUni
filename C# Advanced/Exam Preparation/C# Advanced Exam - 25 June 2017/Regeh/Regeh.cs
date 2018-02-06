using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    public static void Main(string[] args)
    {
        var input = ReadLine();
        var validMatches = Regex.Matches(input, @"\[[^\s\[\]]+(<(\d+)REGEH(\d+)>)[^\s\[\]]+\]");

        var indexSum = 0;
        var sB = new StringBuilder();

        foreach(Match match in validMatches)
        {
            var indexes = match.Groups.Cast<Group>().Where(g => int.TryParse(g.Value, out int t)).Select(g => int.Parse(g.Value));
            foreach(var index in indexes)
            {
                indexSum += index;
                sB.Append(input[indexSum % input.Length]);
            }
        }

        WriteLine(sB.ToString());
    }
}