using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class AddVAT
{
    public static void Main(string[] args)
    {
        var pricesWithVat = ReadLine()
            .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(price => (decimal.Parse(price) * 1.2m).ToString("F2"));

        WriteLine(string.Join("\n", pricesWithVat));
    }
}