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
        int[] array = new int[(int) ReadNum()];
        for (int i = 0; i < array.Length; i++)
            array[i] = (int) ReadNum();

        ReverseArray(array);

        PrintArray(array);
    }

    static void ReverseArray(int[] arr)
    {
        for (int i = 0; i < arr.Length/2; i++)
        {
            int temp = arr[i];
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
