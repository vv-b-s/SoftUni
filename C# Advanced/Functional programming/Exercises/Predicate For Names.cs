using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class PredicateForNames
{
    public static void Main(string[] args)
    {
        int.TryParse(ReadLine(), out int nameLengthLimit);
        var names = ReadLine().Split().Where(name => name.Length <= nameLengthLimit);
        WriteLine(string.Join("\n", names));
    }
}