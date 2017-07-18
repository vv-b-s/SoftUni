using System;
using System.Globalization;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int integer = (int) ReadNum();
        WriteLine($"{Convert.ToString(integer,16).ToUpper()}\n" +
                  $"{Convert.ToString(integer,2)}");
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
