using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        PrintTriangle((int)ReadNum());
    }

    static void PrintTriangle(int number)
    {
        for (int i = 1; i <= number; i++)
        {
            for (int j = 0; j < i; j++)
                Write((j+1) + " ");
            WriteLine();
        }
        for(int i=number-1;i>0;i--)
        {
            for (int j = 1; j <=i; j++)
                Write(j + " ");
            WriteLine();
        }
    }


    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
