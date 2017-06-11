using System;
using System.Linq;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        long[][] array = new long[3][];

        array[0] = Array.ConvertAll(ReadLine().Split(' '), long.Parse);
        array[1] = Array.ConvertAll(ReadLine().Split(' '), long.Parse);

        int longerArray = array[0].Length > array[1].Length ? array[0].Length : array[1].Length;
        array[2] = new long[longerArray];
        for (int i = 0; i < longerArray; i++)
            array[2][i] = array[0][i % array[0].Length] + array[1][i % array[1].Length];
        PrintArray(array[2]);

    }

    static void PrintArray<TArray>(TArray[] arr)
    {
        foreach (var item in arr)
            Write($"{item} ");

        WriteLine();
    }

}
