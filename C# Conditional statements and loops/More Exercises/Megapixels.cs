using System;
using static System.Console;

class Program
{
    static void Main()
    {
        int[] res = { int.Parse(ReadLine()), int.Parse(ReadLine()) };
        WriteLine($"{res[0]}x{res[1]} => {Math.Round(res[0] * res[1] / 1000000d, 1)}MP");
    }
}
