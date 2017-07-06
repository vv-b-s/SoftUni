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
        var strings = Regex.Split(ReadLine(), @"\s").Where(i => i != "").ToList();

        string input;
        while ((input = ReadLine()) != "end")
        {
            var inputIsValid = true;
            var command = input.Split()[0];
            switch (command)
            {
                case "reverse":
                    var startIndex = int.Parse(input.Split()[2]);
                    var len = int.Parse(input.Split()[4]);
                    inputIsValid = startIndex >= 0 && startIndex <= strings.Count - 1 && startIndex + len <= strings.Count && len >= 0;
                    if (inputIsValid)
                        ReverseArrayFrom(ref strings, startIndex, len);
                    else
                        WriteLine("Invalid input parameters.");
                    break;

                case "sort":
                    startIndex = int.Parse(input.Split()[2]);
                    len = int.Parse(input.Split()[4]);
                    inputIsValid = startIndex >= 0 && startIndex <= strings.Count - 1 && startIndex + len <= strings.Count && len >= 0;
                    if (inputIsValid)
                        SortArrayFrom(ref strings, startIndex, len);
                    else
                        WriteLine("Invalid input parameters.");
                    break;

                case "rollLeft":
                    len = int.Parse(input.Split()[1]);
                    inputIsValid = len >= 0;
                    if (inputIsValid)
                        RollArray(strings, "left", len);
                    else
                        WriteLine("Invalid input parameters.");
                    break;

                case "rollRight":
                    len = int.Parse(input.Split()[1]);
                    inputIsValid = len >= 0;
                    if (inputIsValid)
                        RollArray(strings, "right", len);
                    else
                        WriteLine("Invalid input parameters.");
                    break;
            }
        }

        WriteLine($"[{string.Join(", ", strings)}]");
    }

    private static void RollArray(List<string> strings, string rollDirection, int times)
    {
        switch (rollDirection)
        {
            case "left":
                for (int i = 0; i < times%strings.Count; i++)
                {
                    var firstElement = strings[0];
                    for (int j = 1; j < strings.Count; j++)
                        strings[j - 1] = strings[j];
                    strings[strings.Count - 1] = firstElement;
                }
                break;
            case "right":
                for (int i = 0; i < times%strings.Count; i++)
                {
                    var lastElement = strings[strings.Count - 1];
                    for (int j = strings.Count - 2; j >= 0; j--)
                        strings[j + 1] = strings[j];
                    strings[0] = lastElement;
                }
                break;
        }
    }

    private static void SortArrayFrom(ref List<string> strings, int startIndex, int len)
    {
        var firstPart = strings.Take(startIndex);
        var sortedPart = strings.Skip(startIndex).Take(len).ToList();
        sortedPart.Sort();
        var lastPart = strings.Skip(startIndex + len);

        strings = firstPart.Concat(sortedPart).Concat(lastPart).ToList();
    }

    private static void ReverseArrayFrom(ref List<string> strings, int startIndex, int len)
    {
        var firstPart = strings.Take(startIndex);
        var reversedPart = strings.Skip(startIndex).Take(len).Reverse();
        var lastPart = strings.Skip(startIndex + len);

        strings = firstPart.Concat(reversedPart).Concat(lastPart).ToList();
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