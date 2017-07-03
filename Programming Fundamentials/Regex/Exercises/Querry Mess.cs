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
        var sB = new StringBuilder();
        var input = "";
        while ((input = ReadLine()) != "END")
        {
            var rawMatches = Regex.Matches(input.ToString(),
                @"(^|(?<=[\r\n\?\&\+]))[^\?\&\=]+?\=[^\?\&\=]+?($|(?=[\?\&\n\r\=]))")
                .Cast<Match>()
                .Select(rm => rm.Value.Trim())
                .ToList();
            sB.AppendLine(ExtrachtMatches(rawMatches));
        }

        Write(sB.ToString());
    }

    private static string ExtrachtMatches(List<string> rawMatches)
    {
        var keyValue = new Dictionary<string, List<string>>();

        for (int i = 0; i < rawMatches.Count; i++)
        {
            rawMatches[i] = Regex.Replace(rawMatches[i], @"(\+|%20)+", " ");

            var key = Regex.Split(rawMatches[i], @"\=")[0].Trim();
            var value = Regex.Split(rawMatches[i], @"\=")[1].Trim();

            if (keyValue.ContainsKey(key))
                keyValue[key].Add(value);
            else
                keyValue[key] = new List<string> { value };
        }

        var sB = new StringBuilder();
        foreach (var match in keyValue)
            sB.Append($"{match.Key}=[{string.Join(", ",match.Value)}]");
        return sB.ToString();
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