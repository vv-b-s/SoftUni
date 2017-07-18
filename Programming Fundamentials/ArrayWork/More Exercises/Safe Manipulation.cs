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
        string[] arr = ReadLine().Split(' ');

        bool keepLoopWorking = true;
        while(keepLoopWorking)
        {
            try
            {
                string[] command = ReadLine().Split(' ');
                switch (command[0])
                {
                    case "Reverse":
                        Array.Reverse(arr);
                        break;
                    case "Distinct":
                        arr = Distinct(arr);
                        break;
                    case "Replace":
                        Replace(arr, int.Parse(command[1]), command[2]);
                        break;
                    case "END":
                        keepLoopWorking = false;
                        break;
                    default:
                        WriteLine("Invalid input!");
                        break;
                }
            }
            catch (IndexOutOfRangeException)
            {
                WriteLine("Invalid input!");
            }
        }

        for (int i = 0; i < arr.Length; i++)
        {
                Write(i < arr.Length - 1 ?
                    arr[i] + ", " :
                    arr[i]);
        }
        WriteLine();
    }

    static string[] Distinct(string[] arr)
    {
        var sB = new StringBuilder();
        for(int i = 0;i<arr.Length;i++)
        {
            string[] temp = sB.ToString().Split(' ');
            for(int j=0;j<temp.Length;j++)
            {
                if (temp[j] == arr[i])
                    break;
                if (temp[j] != arr[i] && j == temp.Length - 1)
                    sB.Append(i < arr.Length - 1 ?
                    $"{arr[i]} " :
                    $"{arr[i]}");
            }
        }

        return sB.ToString().Trim(' ').Split(' ');
    }

    static void Replace(string[] arr, int pos, string word) => arr[pos] = word;

    static string PrintArray<TVariable>(TVariable[] arr, string format)
    {
        var sB = new StringBuilder();
        for(int i =0;i<arr.Length;i++)
            sB.Append(i!=arr.Length-1?
                $"{arr[i]}{format}":
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
