using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class SortEvenNumbers
{
    public static void Main(string[] args)
    {
        var numbers = ReadLine()
            .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Where(n => n % 2 == 0)
            .OrderBy(n => n);

        WriteLine(string.Join(", ", numbers));
    }
}