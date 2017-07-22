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

        int[] resultArray = new int[arr.Length];
        int k = (int)ReadNum();
        if (arr.Length > 1)
        {
            for (int i = k - 1; i >= 0; i--)
            {
                int valueOne = arr[0];
                for (int j = arr.Length; j > 0; j--)
                    arr[j % arr.Length] = arr[j - 1];
                arr[1] = valueOne;
                SumArrays(arr, resultArray);
            }
            WriteLine(PrintArray(resultArray, " "));
        }
        else
            WriteLine(PrintArray(arr, " "));

    }

    static string PrintArray<TVariable>(TVariable[] arr, string format)
    {
        var sB = new StringBuilder();
        foreach (var a in arr)
            sB.Append($"{a}{format}");
        return sB.ToString();
    }

    static void SumArrays(int[] arr, int[] res)
    {
        for (int i = 0; i < arr.Length; i++)
            res[i] += arr[i];
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
