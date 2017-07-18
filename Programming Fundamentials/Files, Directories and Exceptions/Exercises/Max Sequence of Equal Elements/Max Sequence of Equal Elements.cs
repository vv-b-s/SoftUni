using System;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Numerics;
using System.IO;
using static System.Console;

class Program
{
    static void Main()
    {
        var lines = File.ReadLines(@"X:\Development\SoftUni\Files, Directories and Exceptions\Exercises\Max Sequence of Equal Elements\input.txt");
        var sB = new StringBuilder();

        foreach (var line in lines)
        {
            int[] arr = Array.ConvertAll(line.Split(' '), int.Parse);

            int length = 1, bestLength = length;
            int start = 0, bestStart = start;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i - 1])
                {
                    length++;
                    start = i - length + 1;
                }
                else if (arr[i] != arr[i - 1] && length > bestLength)
                {
                    bestLength = length;
                    bestStart = start;
                    length = 1;
                }
                else
                {
                    length = 1;
                }
            }
            if (length > bestLength)
            {
                bestLength = length;
                bestStart = start;
            }

            for (int i = bestStart; i < bestLength + bestStart; i++)
                sB.Append(arr[i] + " ");
            sB.AppendLine(); 
        }
        File.WriteAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\Exercises\Max Sequence of Equal Elements\output.txt", sB.ToString());
    }

    static string PrintArray<TVariable>(TVariable[] arr, string format)
    {
        var sB = new StringBuilder();
        foreach (var a in arr)
            sB.Append($"{a}{format}");
        return sB.ToString();
    }

}
