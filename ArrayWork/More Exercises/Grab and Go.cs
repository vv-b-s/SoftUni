using System;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Numerics;
using static System.Console;

class Program
{
    static void Main()
    {
        int[] arr = Array.ConvertAll(ReadLine().Split(' '), int.Parse);
        int stopInt = (int)ReadNum();
        int occurancePos = 0;
        bool occuranceFound = false;

        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == stopInt)
            {
                occurancePos = i;
                occuranceFound = true;
            }

        long sumOfIndexes = 0;
        for (int i = 0; i < occurancePos; i++)
            sumOfIndexes += arr[i];

        WriteLine(occuranceFound? sumOfIndexes.ToString(): "No occurrences were found!");
    }

    static string PrintArray<TVariable>(TVariable[] arr, string format)
    {
        var sB = new StringBuilder();
        foreach (var a in arr)
            sB.Append($"{a}{format}");
        return sB.ToString();
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
