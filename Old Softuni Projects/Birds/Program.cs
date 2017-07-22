using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int birds = (int)ReadNum();
        int fethers = (int)ReadNum();

        decimal number = (decimal)fethers / birds;
        if (birds % 2 == 0)
            number *= 123123123123m;
        else
            number /= 317m;
        WriteLine($"{Math.Round(number, 4):0.0000}");
    }


    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}