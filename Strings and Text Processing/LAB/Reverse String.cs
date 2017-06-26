using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

class Program
{
    static void Main()
    {
        string word = ReadLine();

        for (int i = word.Length - 1; i >= 0; i--)
            Write(word[i]);
        WriteLine();
    }
}