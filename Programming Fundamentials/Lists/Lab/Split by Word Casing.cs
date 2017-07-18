using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        string raw = ReadLine();
        var rawList = raw.Split(',', ';', ':', '.', '!', '(', ')', '\"', '\'', '\\', '/', '[', ']', ' ').ToList();

        var lowerCaseList = new List<string>();
        var mixedCaseList = new List<string>();
        var upperCaseList = new List<string>();

        foreach (var item in rawList)
        {
            if (item.All(t => char.IsLower(t)))
                lowerCaseList.Add(item);
            else if (item.All(t => char.IsUpper(t)))
                upperCaseList.Add(item);
            else
                mixedCaseList.Add(item);
        }

        lowerCaseList.RemoveAll(t => t == "");
        mixedCaseList.RemoveAll(t => t == "");
        upperCaseList.RemoveAll(t => t == "");

        WriteLine($"Lower-case: {string.Join(", ", lowerCaseList)}\n" +
            $"Mixed-case: {string.Join(", ", mixedCaseList)}\n" +
            $"Upper-case: {string.Join(", ", upperCaseList)}");

    }

    static void RemoveEmptyCells(ref string[] arr)
    {
        List<string> raw = arr.ToList();
        raw.RemoveAll(t => t == "");
        arr = raw.ToArray();
    }
}