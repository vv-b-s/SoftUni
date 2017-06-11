using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        string name = TakeName(ReadLine());
        WriteLine($"Hello, {name}!");
    }

    static string TakeName(string name) => name;
}
