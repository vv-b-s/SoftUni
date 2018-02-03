using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class ReverseAndExclude
{
    public static void Main(string[] args)
    {
        var integers = ReadLine().Split().Select(int.Parse);

        int.TryParse(ReadLine(), out int divisibleNumber);

        integers = integers.Where(i => i % divisibleNumber != 0).Reverse();

        WriteLine(string.Join(" ", integers));
    }
}