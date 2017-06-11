using System;
using static System.Console;

class Program
{
    static void Main()
    {
        string noun = ReadLine();
        if (noun.EndsWith("y"))
        {
            noun = noun.Remove(noun.Length - 1);
            WriteLine(noun + "ies");
        }
        else if (noun.EndsWith("o") || noun.EndsWith("ch") || noun.EndsWith("s") || noun.EndsWith("sh") || noun.EndsWith("x") || noun.EndsWith("z"))
            WriteLine(noun + "es");
        else
            WriteLine(noun + 's');
    }
}
