using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        string number = ReadLine();
        for (int i = 1; i <= int.Parse(number); i++)
        {
            if (i.ToString().Length == 1)
                WriteLine($"{i} -> {i == 5 || i == 7}");
            else
            {
                double iSUM = char.GetNumericValue(i.ToString()[0]) + char.GetNumericValue(i.ToString()[1]);
                WriteLine($"{i} -> {iSUM == 5 || iSUM == 7 || iSUM == 11}");
            }
        }
    }


    static double ReadNum()
    {
        string input = ReadLine();
        double output;
        double.TryParse(input, out output);
        return output;
    }
}
