using System;
using System.Linq;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        string[] array = ReadLine().Split(' ');
        ReverseArray(array);
        PrintArray(array);
    }

    static void ReverseArray<TArray>(TArray[] arr)
    {
        for (int i = 0; i < arr.Length/2; i++)
        {
            TArray temp = arr[i];
            int itemToBeMoved = arr.Length - 1 - i;
            arr[i] = arr[itemToBeMoved];
            arr[itemToBeMoved] = temp;
        }
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
