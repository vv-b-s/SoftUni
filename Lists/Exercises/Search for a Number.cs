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
        string manipulations = ReadLine();
        int[] manipulationsToInt = Array.ConvertAll(manipulations.Split(), int.Parse);
        int newArrayLength = manipulationsToInt[0];
        int numberOfItemsToBeRemoved = manipulationsToInt[1];
        int numberToFind = manipulationsToInt[2];

        var newList = new List<int>();
        for (int i = 0; i < newArrayLength; i++)
            newList.Add(rawList[i]);
        newList.RemoveRange(0, numberOfItemsToBeRemoved);
        WriteLine(newList.Contains(numberToFind) ? "YES!" : "NO!");
    }

    static string[] CleanArray(string[] arr)
    {
        List<string> raw = arr.ToList();
        raw.RemoveAll(t => t == "");
        return raw.ToArray();
    }
}