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
        int[] arr = Array.ConvertAll(ReadLine().Split(),int.Parse);

        int landedSum = arr[0];
        int step = arr[0];

        int currPos = 0;

        while(true)
        {
            if (step + currPos < arr.Length)
            {
                currPos += step;
                step = arr[currPos];
                landedSum += step;
            }
            else if (currPos-step >= 0)
            {
                currPos -= step;
                step = arr[currPos];
                landedSum += step;
            }
            else
                break;
        }
        WriteLine(landedSum);
    }

    static string PrintArray<TVariable>(TVariable[] arr, string format)
    {
        var sB = new StringBuilder();
        for (int i = 0; i < arr.Length; i++)
            sB.Append(i < arr.Length - 1 ?
                $"{arr[i]}{format}" :
                $"{arr[i]}");

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
