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
        double[] arr = Array.ConvertAll(ReadLine().Split(' '), double.Parse);
        Array.Sort(arr);

        WriteLine($"Min = {arr[0]}\n" +
            $"Max = {arr[arr.Length - 1]}\n" +
            $"Sum = {SumArray(arr)}\n" +
            $"Average = {Average(arr)}");
    }

    static double SumArray(double[] arr)
    {
        double sum = 0;
        foreach (var i in arr)
            sum += i;
        return sum;
    }

    static double Average(double[] arr) => SumArray(arr) / arr.Length;
}
