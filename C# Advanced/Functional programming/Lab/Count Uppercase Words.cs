using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class CountUppercaseWords
{
    public static void Main(string[] args)
    {
        var uppercaseWords = ReadLine()
            .Split()
            .Where(word => word.Any(char.IsUpper));

        WriteLine(string.Join("\n", uppercaseWords));
    }
}