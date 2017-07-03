using System;
using System.Globalization;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int centuries = (int) ReadNum();
        uint years = (uint) (centuries * 100);
        ulong days = (ulong) (years * 365.2422);
        ulong hours = days * 24;
        ulong minutes = hours * 60;
        decimal seconds = minutes * 60;
        decimal milliseconds = seconds * 1000;
        decimal microseconds = milliseconds * 1000;
        decimal nanoseconds = microseconds * 1000;

        WriteLine($"{centuries} centuries = " +
                  $"{years} years = " +
                  $"{days} days = " +
                  $"{hours} hours = " +
                  $"{minutes} minutes = " +
                  $"{seconds} seconds = " +
                  $"{milliseconds} milliseconds = " +
                  $"{microseconds} microseconds = " +
                  $"{nanoseconds} nanoseconds");
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
