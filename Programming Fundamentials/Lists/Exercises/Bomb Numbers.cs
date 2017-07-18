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
        string bomb = ReadLine();
        var bombNumber = int.Parse(bomb.Split()[0]);
        var power = int.Parse(bomb.Split()[1]);

        if (power == 0)
            rawList.RemoveAll(b => b == bombNumber);
        else
        {
            for (int i = 0; i < rawList.Count; i++)
            {

                if (rawList[i] == bombNumber)
                {
                    var tempList = new List<int>();
                    for (int j = 0; j < i - power; j++)
                        tempList.Add(rawList[j]);
                    for (int j = i + power + 1; j < rawList.Count; j++)
                        tempList.Add(rawList[j]);
                    rawList = tempList;
                }
            }
        }

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