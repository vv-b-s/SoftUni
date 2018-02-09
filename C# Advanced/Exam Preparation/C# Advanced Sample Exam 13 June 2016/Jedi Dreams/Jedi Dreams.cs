using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var methodsIvokes = new Dictionary<string, List<string>>();

        var numberOfLines = int.Parse(ReadLine());

        var stackTrace = "";
        while (numberOfLines-- > 0)
        {
            var line = ReadLine();

            if (Regex.IsMatch(line, @"static\s+.*\s+(?<methodName>[a-zA-Z]*[A-Z][a-zA-Z]*)\s*\("))
            {
                var match = Regex.Match(line, @"static\s+.*\s+(?<methodName>[a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(");

                var methodName = match.Groups["methodName"].Value;

                if (!methodsIvokes.ContainsKey(methodName))
                    methodsIvokes[methodName] = new List<string>();

                stackTrace = methodName;
            }
            else if (Regex.IsMatch(line, @"(?<methodName>[a-zA-Z]*[A-Z][a-zA-Z]*)\s*\("))
            {
                var matches = Regex.Matches(line, @"(?<methodName>[a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(").Cast<Match>().Select(m => m.Groups["methodName"].Value).ToArray();

                foreach (var method in matches)
                {
                    methodsIvokes[stackTrace].Add(method);
                }
            }
        }

        methodsIvokes = methodsIvokes.OrderByDescending(m => m.Value.Count).ThenBy(k => k.Key).ToDictionary(k => k.Key, v => v.Value);

        var sB = new StringBuilder();
        foreach (var method in methodsIvokes)
        {
            var invokes = method.Value.OrderBy(i => i).ToList();
            if (invokes.Count > 0)
                sB.AppendLine($"{method.Key} -> {method.Value.Count} -> {string.Join(", ", invokes)}");
            else
                sB.AppendLine($"{method.Key} -> None");
        }

        Write(sB);
    }
}