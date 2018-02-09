using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    private static string[] numberNames = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    static void Main()
    {
        var numbers = ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
        var orderedNumbers = numbers.OrderBy(n => MakeAWord(n));

        WriteLine(string.Join(", ", orderedNumbers));
    }

    private static string MakeAWord(string number) => string.Join("-", number.Select(n => numberNames[(int)char.GetNumericValue(n)]));
}