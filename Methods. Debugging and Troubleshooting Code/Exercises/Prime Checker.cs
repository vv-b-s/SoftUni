using System;
using System.Globalization;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        WriteLine(CheckPrime((long)ReadNum()));
    }

    public static bool CheckPrime(long number)
    {
        if (number == 1|| number==0) return false;
        if (number == 2) return true;

        var boundary = (long)Math.Floor(Math.Sqrt(number));

        for (long i = 2; i <= boundary; ++i)
            if (number % i == 0) return false;

        return true;
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
