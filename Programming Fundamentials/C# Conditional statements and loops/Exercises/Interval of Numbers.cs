using System;
using static System.Console;

class Program
{
    static void Main()
    {
        int[] number = { int.Parse(ReadLine()), int.Parse(ReadLine()) };
        for (int i = Math.Min(number[0], number[1]); i <= Math.Max(number[0], number[1]); i++)
            WriteLine(i);
    }
}
