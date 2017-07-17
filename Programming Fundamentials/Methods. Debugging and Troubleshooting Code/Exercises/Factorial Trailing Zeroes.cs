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
        WriteLine(CalculateTrailingZeroes(Factorial((long)ReadNum()).ToString()));
    }

    static BigInteger Factorial(BigInteger number)
    {
        if (number == 0)
            return 1;
        return number * Factorial(number - 1);
    }

    static int CalculateTrailingZeroes(string number)
    {
        int zeroes = 0;
        for (int i = number.Length - 1; number[i] == '0'; i--)
            zeroes++;
        return zeroes;
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
