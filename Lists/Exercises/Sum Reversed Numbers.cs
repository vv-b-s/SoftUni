using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var stringList = ReadLine().Split().ToList();

        for (int i = 0; i < stringList.Count; i++)
            stringList[i] = new string(stringList[i].Reverse().ToArray());

        var rawList = stringList.Select(int.Parse).ToList();

        var sum = 0;
        foreach (var item in rawList)
            sum += item;

        WriteLine(sum);          
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