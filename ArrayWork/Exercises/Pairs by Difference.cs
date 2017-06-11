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

        int number = (int)ReadNum();

        int pairs = 0;
        for (int i = 0; i < arr.Length - 1; i++)
            for (int j = i+1; j < arr.Length; j++)
                if (Math.Abs(arr[i] - arr[j]) == number)
                    pairs++;

        WriteLine(pairs);
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
