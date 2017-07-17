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
        var usernames = Regex.Matches(ReadLine(),
            @"(^|(?<=[\s\,\\\/\(\)]))([A-Za-z]([0-9a-zA-Z](_?[0-9a-zA-Z]+)*)*){3,25}($|(?=[\s\,\\\/\(\)]))")
            .Cast<Match>()
            .Select(m=>m.Value)
            .ToList();

        usernames.RemoveAll(un => un.Length > 25);

        if (usernames.Count < 3)
            WriteLine(string.Join("\n", usernames));
        else
        {
            var pairLength = new Dictionary<string, int>();
            for (int i = 1; i < usernames.Count; i++)
                pairLength[$"{usernames[i-1]}\n{usernames[i]}"] = usernames[i].Length + usernames[i - 1].Length;

            var highestLength = pairLength.Max(p => p.Value);
            var leftmostPair = pairLength.First(p => p.Value == highestLength);
            WriteLine(leftmostPair.Key);
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