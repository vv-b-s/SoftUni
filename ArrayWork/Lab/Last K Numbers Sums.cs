using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection.Emit;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        long[] seq = new long[(long) ReadNum()];
        seq[0] = 1;

        long k = (long) ReadNum();
        for (long i = 1; i < seq.Length; i++)
        {
            long maxDecrement = i - k >= 0 ? i - k : 0;
            for (long j = i; j >= maxDecrement; j--)
                seq[i] += seq[j];
        }
        PrintArray(seq);
    }



    static void PrintArray<TArray>(TArray[] arr)
    {
        foreach (var item in arr)
            Write($"{item} ");

        WriteLine();
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
