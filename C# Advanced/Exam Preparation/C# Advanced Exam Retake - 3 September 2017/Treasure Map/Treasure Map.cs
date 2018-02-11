using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class TreasureMap
{
    public static void Main(string[] args)
    {
        var numberOfLines = int.Parse(ReadLine());

        var lines = new string[numberOfLines];
        for (int i = 0; i < lines.Length; i++)
            lines[i] = ReadLine();

        foreach(var line in lines)
        {
            var patterns = GetPatterns(line);
            var validMessage = GetValidMessage(line, patterns);

            if(validMessage!=null)
                WriteLine($"Go to str. {validMessage[0]} {validMessage[1]}. Secret pass: {validMessage[2]}.");
        }
    }

    private static List<string> GetPatterns(string line)
    {
        var linesFromPatterns = Regex.Matches(line, @"![^#!]+#")
            .Cast<Match>()
            .Select(m => m.Value)
            .Concat(Regex.Matches(line, @"#[^#!]+!")
            .Cast<Match>().
            Select(m => m.Value));

        return linesFromPatterns.ToList();
    }

    private static string[] GetValidMessage(string line, List<string> patterns)
    {
        var validations = new Regex[] { new Regex(@"[^A-Za-z0-9](?<streetName>[A-Za-z]{4})[^A-Za-z0-9]"), new Regex(@"\D(?<streetNumber>\d{3})-(?<password>(\d{4})|(\d{6}))\D") };

        //get the valid patterns
        var validPatterns = patterns.Where(pattern => validations.All(validation => validation.IsMatch(pattern)));

        //Position the patterns accurately
        var patternsPosition = new Dictionary<int, string>();
        foreach(var validPattern in validPatterns)
        {
            var indexOfPattern = line.IndexOf(validPattern);
            patternsPosition[indexOfPattern] = validPattern;
        }

        //Sort the patterns
        patternsPosition = patternsPosition.OrderBy(p => p.Key).ToDictionary(k=>k.Key, v=>v.Value);

        if (patternsPosition.Count > 0)
        {
            //Get the middle pattern
            var middlePattern = patternsPosition.Values.ToArray()[patternsPosition.Count / 2];

            //Get the parameters of the pattern
            var streetName = validations[0].Match(middlePattern).Groups["streetName"].Value;

            var addressDetails = validations[1].Matches(middlePattern).Cast<Match>().Last();
            var streetNumber = addressDetails.Groups["streetNumber"].Value;
            var password = addressDetails.Groups["password"].Value;

            return new string[] { streetName, streetNumber, password };
        }
        else return null;
    }
}