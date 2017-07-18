using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using static System.Console;

class Program
{
    static void Main()
    {
        WriteLine(Factorial(BigInteger.Parse(ReadLine())));
    }

    static BigInteger Factorial(BigInteger number)
    {
        if (number == 0)
            return 1;
        return number * Factorial(number - 1);
    }
}