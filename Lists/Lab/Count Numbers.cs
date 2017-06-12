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

        var numbersCount = new Dictionary<int, double>();
        for(int i=0;i<rawList.Count;i++)
        {
            if (numbersCount.ContainsKey(rawList[i]))
                numbersCount[rawList[i]]++;
            else
                numbersCount.Add(rawList[i], 1);
        }

        rawList = rawList.Distinct().ToList();
        rawList.Sort();

        foreach(var number in rawList)
            WriteLine(number + " -> " + numbersCount[number]);
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