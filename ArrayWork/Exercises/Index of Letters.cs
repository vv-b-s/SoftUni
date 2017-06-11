using System;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Numerics;
using static System.Console;

class Program
{
    static void Main()
    {
        string arr = ReadLine().ToLower();
        foreach(char ch in arr)
        {
            WriteLine($"{ch} -> {ch - 97}");
        }

    }
}
