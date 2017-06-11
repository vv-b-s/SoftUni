using System;
using System.Globalization;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int maxNum = (int)ReadNum();
        for (int num = 2; num <= maxNum; num++)
        {
            bool isPrime = true;
            for (int divNum = 2; Math.Pow(divNum,2) <= num; divNum++)
            {
                if (num % divNum == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            Console.WriteLine($"{num} -> {isPrime}");
        }
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
