using System;
using System.Text;
using System.Linq;
using static System.Console;

class Program
{
    static void Main()
    {
        WriteLine(Fib((int)ReadNum()));
    }

    public static int Fib(int n)
    {
        int a = 0;
        int b = 1;

        for (int i = 0; i <= n; i++)
        {
            int temp = a;
            a = b;
            b = temp + b;
        }
        return a;
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
