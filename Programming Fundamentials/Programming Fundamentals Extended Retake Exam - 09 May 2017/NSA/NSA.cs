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
        var countriesAndSpies = new Dictionary<string, Dictionary<string, long>>();
        var listOfCountrues = new List<string>();
        string input;
        while ((input = ReadLine()) != "quit")
        {
            var match = Regex.Match(input, @"(?<country>\w+) -> (?<spy>\w+) -> (?<dos>\d+)");
            var country = match.Groups["country"].Value;
            var spyName = match.Groups["spy"].Value;
            var daysOfService = long.Parse(match.Groups["dos"].Value);

            if (countriesAndSpies.ContainsKey(country))
                countriesAndSpies[country][spyName] = daysOfService;
            else
            {
                countriesAndSpies[country] = new Dictionary<string, long> { { spyName, daysOfService } };
                listOfCountrues.Add(country);
            }
        }

        foreach (var country in listOfCountrues)
            countriesAndSpies[country] = countriesAndSpies[country].OrderByDescending(s => s.Value).ToDictionary(k => k.Key, v => v.Value);

        countriesAndSpies = countriesAndSpies.OrderByDescending(c => c.Value.Count).ToDictionary(k => k.Key, v => v.Value);

        foreach(var spyset in countriesAndSpies)
        {
            WriteLine($"Country: {spyset.Key}");
            foreach (var spy in spyset.Value)
                WriteLine($"**{spy.Key} : {spy.Value}");
        }
    }
}
