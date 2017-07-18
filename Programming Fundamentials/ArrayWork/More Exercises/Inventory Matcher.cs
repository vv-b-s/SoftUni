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
        string[] products = ReadLine().Split(' ');
        long[] quantities = Array.ConvertAll(ReadLine().Split(' '), long.Parse);
        string[] prices = ReadLine().Split(' ');

        string userInput;
        while((userInput = ReadLine())!="done")
        {
            for(int i=0;i<products.Length;i++)
                if(products[i]==userInput)
                    WriteLine($"{products[i]} costs: {prices[i]}; Available quantity: {quantities[i]}");
        }
    }

    static string PrintArray<TVariable>(TVariable[] arr, string format)
    {
        var sB = new StringBuilder();
        for (int i = 0; i < arr.Length; i++)
            sB.Append(i < arr.Length - 1 ?
                $"{arr[i]}{format}" :
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
