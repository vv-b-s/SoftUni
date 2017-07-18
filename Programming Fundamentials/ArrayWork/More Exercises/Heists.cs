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
        long[] prices = Array.ConvertAll(ReadLine().Split(' '), long.Parse);
        long jewelPrice = prices[0], goldPrice = prices[1];
        long expences = 0, totalRevenue = 0;

        string userInput;

        while((userInput=ReadLine())!= "Jail Time")
        {
            string loot = userInput.Split(' ')[0];
            expences += long.Parse(userInput.Split(' ')[1]);
            foreach(var item in loot)
            {
                if (item == '%')
                    totalRevenue += jewelPrice;
                else if (item == '$')
                    totalRevenue += goldPrice;
            }
        }

        WriteLine(totalRevenue >= expences ?
            $"Heists will continue. Total earnings: {totalRevenue - expences}." :
            $"Have to find another job. Lost: {expences-totalRevenue}.");
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
