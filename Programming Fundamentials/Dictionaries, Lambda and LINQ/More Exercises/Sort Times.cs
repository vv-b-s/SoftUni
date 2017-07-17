using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var times = ReadLine().Split().ToList().OrderBy(t=>t);
        WriteLine(string.Join(", ",times));
    }
}