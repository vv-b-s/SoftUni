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
        var lines = File.ReadAllLines(@"X:\Development\SoftUni\Files, Directories and Exceptions\Exercises\Equal sums\input.txt");
        var sB = new StringBuilder();
        foreach (var line in lines)
        {
            int[] arr = Array.ConvertAll(line.Split(' '), int.Parse);
            bool cont = false;
            for (int i = 0; i < arr.Length; i++)
                if (SumOfTheLeftSide(arr, i) == SumOfTheRightSide(arr, i))
                {
                    sB.AppendLine(i.ToString());
                    cont = true;
                    break;
                }
            if (cont)
                continue;
            sB.AppendLine(arr.Length == 1 ? "0" : "no"); 
        }
        File.WriteAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\Exercises\Equal sums\output.txt", sB.ToString());
    }

    static int SumOfTheLeftSide(int[] arr, int stopIndex)
    {
        int sum = 0;
        for (int i = 0; i < stopIndex; i++)
            sum += arr[i];
        return sum;
    }

    static int SumOfTheRightSide(int[] arr, int stopIndex)
    {
        int sum = 0;
        for (int i = arr.Length - 1; i > stopIndex; i--)
            sum += arr[i];
        return sum;
    }

    static string PrintArray<TVariable>(TVariable[] arr, string format)
    {
        var sB = new StringBuilder();
        foreach (var a in arr)
            sB.Append($"{ a}{format}");
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
