using System;
using static System.Console;

class Program
{
    static void Main()
    {
        int num = 0;
        int temp;
        while (int.TryParse(ReadLine(), out temp))
            num++;
        WriteLine(num);
    }
}
