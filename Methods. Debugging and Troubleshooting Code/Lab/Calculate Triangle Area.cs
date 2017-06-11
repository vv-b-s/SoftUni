using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        WriteLine(CalculateArea((double)ReadNum(), (double)ReadNum()));
    }

    static double CalculateArea(double width, double height) => height * width / 2;



    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
