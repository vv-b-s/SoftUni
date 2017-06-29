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
        var pattern = @"\b(?<day>\d{2})(\.|-|\/)(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";
        var text = ReadLine();
        var matches = Regex.Matches(text,pattern);
        foreach(Match match in matches)
        {
            var day = match.Groups["day"].Value;
            var month = match.Groups["month"].Value;
            var year = match.Groups["year"].Value;

            WriteLine($"Day: {day}, Month: {month}, Year: {year}");
        }
        
    }

}