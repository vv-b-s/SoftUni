using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var rawList = CleanArray(ReadLine().Trim().Split()).Select(double.Parse).ToList();

        var occurances = new SortedDictionary<double, int>();
        foreach(var item in rawList)
        {
            if (occurances.Keys.Contains(item))
                occurances[item]++;
            else
                occurances.Add(item, 1);
        }

        

        foreach (var item in occurances)
            WriteLine($"{item.Key} -> {item.Value}");
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