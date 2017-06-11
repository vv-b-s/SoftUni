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
        long inputNumber = (long)ReadNum();
        bool[] A = new bool[inputNumber + 3];
        for (long i = 2; i <= inputNumber; i++)
            A[i] = true;

        A[0] = A[1] = A[A.Length - 1] = false;


        for (long i = 2; i <= Math.Sqrt(inputNumber); i++)
            if (A[i])
                for (long j = i * i, k = 1; j <= inputNumber; j = i * i + k * i, k++)
                    A[j] = false;

        var output = new StringBuilder();
        for (long i = 0; i < A.Length; i++)
            if (A[i])
                output.Append($"{i} ");

        WriteLine(output.ToString());
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
