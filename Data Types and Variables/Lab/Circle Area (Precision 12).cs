using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        double radius = ReadNum();
        WriteLine((Math.Pow(radius,2)*Math.PI).ToString("f12"));

    }


    static double ReadNum()
    {
        string input = ReadLine();
        double output;
        double.TryParse(input, out output);
        return output;
    }
}
