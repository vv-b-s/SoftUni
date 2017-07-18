using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

class Program
{
    static void Main()
    {
        var str = ReadLine();
        var substring = ReadLine();
        int occurances = 0;


        for (int i = 0; i < str.Length; i++)
        {
            var sub = str.Substring(i, substring.Length % (str.Length - i + 1));
            if (string.Compare(sub,substring,true)==0)
                occurances++;
        }

        WriteLine(occurances);
    }
}