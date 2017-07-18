using System;
using System.Globalization;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        double numberA = (double)ReadNum();
        double numberB = (double)ReadNum();

        WriteLine(Math.Abs(numberA-numberB)<0.000001);
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
