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

        var item1 = rawList.Take((rawList.Count / 2) / 2).ToList();
        item1.Reverse();

        var item2 = rawList.Skip(rawList.Count- (rawList.Count / 2) / 2).ToList();
        item2.Reverse();

        int numToRemove = (rawList.Count / 2) / 2;
        rawList.RemoveRange(0, (rawList.Count / 2) / 2);
        rawList.RemoveRange(rawList.Count - numToRemove, numToRemove);

        var itemsList = item1.Concat(item2).ToList();

        int[] output = new int[itemsList.Count];
        for(int i=0;i<itemsList.Count;i++)
            output[i] = itemsList[i] + rawList[i];

        WriteLine(string.Join(" ", output));
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