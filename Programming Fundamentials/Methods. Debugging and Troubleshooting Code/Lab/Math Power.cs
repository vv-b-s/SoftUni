using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        WriteLine(CalculateArea((double)ReadNum(), (double)ReadNum()));
    }

    static double CalculateArea(double number, double power)
    {
        double output = number;
        if (power > 1 || power < -1)
        {
            for (int i = 1; i < Math.Abs(power); i++)
                output*=power>0?number:(number*-1);
            return output;
        }
        else if (power == 1)
            return number;
        else
            return 1;
    }



    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
