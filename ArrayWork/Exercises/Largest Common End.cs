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
        string[][] array =
        {
            ReadLine().Split(' '),
            ReadLine().Split(' '),
        };

        int commonItemsFromLeft = FindCommon(array);
        Array.Reverse(array[0]);
        Array.Reverse(array[1]);
        int commonFromRight = FindCommon(array);

        WriteLine(commonFromRight > commonItemsFromLeft ? commonFromRight : commonItemsFromLeft);
    }

    static int FindCommon(string[][]arr)
    {
        int shortestLength = arr[0].Length < arr[1].Length ? arr[0].Length : arr[1].Length;
        var sB = new StringBuilder();
        for (int i = 0; i < shortestLength; i++)
            if (arr[0][i] == arr[1][i])
                sB.Append(arr[0][i]+" ");

        string[] outp = sB.ToString().Trim().Split(' ');
        return outp.Contains(string.Empty) ? 0 : outp.Length;
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
