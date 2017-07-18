using System;
using static System.Console;

class Program
{
    static void Main()
    {
        double[] x_1 = { (double)ReadNum(), (double)ReadNum() }, x_2 = { (double)ReadNum(), (double)ReadNum() }, x = { (double)ReadNum(), (double)ReadNum() };

        if (x[0] >= Math.Min(x_1[0], x_2[0]) && x[0] <= Math.Max(x_1[0], x_2[0]) && x[1] >= Math.Min(x_1[1], x_2[1]) && x[1] <= Math.Max(x_1[1], x_2[1]))
            WriteLine("Inside");
        else
            WriteLine("Outside");

    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
