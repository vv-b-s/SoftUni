using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        sbyte sbytes = (sbyte) ReadNum();
        byte bytes = (byte) ReadNum();
        int ints = (int) ReadNum();
        uint uints = (uint) ReadNum();
        ulong ulongs = (ulong) ReadNum();
        long longs = (long) ReadNum();
        decimal decimals = ReadNum();

        WriteLine($"{sbytes}\n" +
                  $"{bytes}\n" +
                  $"{ints}\n" +
                  $"{uints}\n" +
                  $"{ulongs}\n" +
                  $"{longs}\n" +
                  $"{decimals}");
    }


    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
