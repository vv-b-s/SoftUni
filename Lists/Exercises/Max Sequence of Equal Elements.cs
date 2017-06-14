using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var rawList = CleanArray(ReadLine().Trim().Split()).Select(int.Parse).ToList();

        var repeatings = new Dictionary<int, int>();

        foreach(var item in rawList)
        {
            if (repeatings.ContainsKey(item))
                repeatings[item]++;
            else
                repeatings.Add(item, 1);
        }

        var maxRepeatedTims = FindMaxValue(repeatings);
        var mostRepeatedValue = repeatings.First(t => t.Value == maxRepeatedTims).Key;

        for (int i = 0; i < maxRepeatedTims; i++)
            Write(mostRepeatedValue+" ");
        WriteLine();
    }

    static int FindMaxValue(Dictionary<int,int> dict)
    {
        var maxValue = int.MinValue;
        foreach (var item in dict)
            maxValue = item.Value > maxValue ? item.Value : maxValue;
        return maxValue;
    }

    static string[] CleanArray(string[] arr)
    {
        List<string> raw = arr.ToList();
        raw.RemoveAll(t => t == "");
        return raw.ToArray();
    }
}