using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using static System.Console;
using System.Globalization;

class Program
{
    static void Main()
    {
        var strings = ReadLine().Split();

        int shortestStringLength = strings.Min(s => s.Length);

        var values = new int[strings.Max(s => s.Length)];

        for (int i = 0; i < shortestStringLength; i++)
            values[i] = strings[0][i] * strings[1][i];

        if(shortestStringLength<values.Length)
        {
            var longestString = strings.First(s => s.Length == values.Length);
            for (int i = shortestStringLength; i < values.Length; i++)
                values[i] = longestString[i];
        }

        WriteLine(values.Sum());
    }
}