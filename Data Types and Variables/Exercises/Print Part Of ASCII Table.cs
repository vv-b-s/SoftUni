using System;
using System.Globalization;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int asciiStart = (int) ReadNum();
        int asciiEnd = (int) ReadNum();

        for(int i=asciiStart;i<=asciiEnd;i++)
            Write($"{(char)i} ");
        WriteLine();
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
