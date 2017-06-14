using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var input = ReadLine()
            .Trim()
            .ToLower()
            .Split(' ', '.', ',', ':', '(', ')', '[', ']', '\"', '\'', '\\', '/', '!', '?')
            .Where(w=>w.Length<5)
            .Distinct()
            .ToList();

        input.RemoveAll(x => x == "");

        var orderedItems = new SortedDictionary<string, int>();
        foreach(var word in input)
        {
            if (orderedItems.Keys.Contains(word))
                orderedItems[word]++;
            else
                orderedItems.Add(word, 1);
        }

        WriteLine(string.Join(", ", orderedItems.Keys));
    }

    static string[] CleanArray(string[] arr)
    {
        List<string> raw = arr.ToList();
        raw.RemoveAll(t => t == "");
        return raw.ToArray();
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}