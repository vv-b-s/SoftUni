using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class  SumNumbers
{
    public static void Main(string[] args)
    {
        var numbers = ReadLine()
            .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);

        WriteLine($"{numbers.Count()}\n{numbers.Sum()}");
    }
}