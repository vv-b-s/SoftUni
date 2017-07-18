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
        string[] quant = ReadLine().Split();
        decimal[] prices = Array.ConvertAll(ReadLine().Split(' '), decimal.Parse);

        decimal[] quantities = new decimal[products.Length];
        for (int i = 0; i < quant.Length; i++)
            quantities[i] = decimal.Parse(quant[i]);

        while(true)
        {
            string[] userInput = ReadLine().Split();
            if (userInput[0] == "done")
                break;

            string productName = userInput[0];
            long productQuantity = long.Parse(userInput[1]);
            for (int i=0;i<products.Length;i++)
                if(products[i]==productName)
                {
                    WriteLine(quantities[i] >= productQuantity ?
                        $"{products[i]} x {productQuantity} costs {(prices[i] * productQuantity):f2}":
                        $"We do not have enough {productName}");

                    if (quantities[i] >= productQuantity)
                        quantities[i] -= productQuantity;
                    break;
                }
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
