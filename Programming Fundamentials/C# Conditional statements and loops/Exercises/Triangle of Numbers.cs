using System;
using static System.Console;

class Program
{
    static void Main()
    {
        int num = int.Parse(ReadLine());
        for (int i = 0; i < num; i++)
        {
            for (int j = 0; j <= i; j++)
                Write(i+1 + " ");
            WriteLine();
        }
    }
}
