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
        WriteLine(Facrorial((BigInteger)ReadNum()));
    }

    static BigInteger Facrorial(BigInteger number)
    {
        if (number == 0)
            return 1;
        return number * Facrorial(number - 1);
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
