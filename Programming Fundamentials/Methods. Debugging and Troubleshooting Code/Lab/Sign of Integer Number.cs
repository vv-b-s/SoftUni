using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        PrintSign((int)ReadNum());
    }

    static void PrintSign(int number)
    {
        if (number > 0)
            WriteLine($"The number {number} is positive.");
        else if(number<0)
            WriteLine($"The number {number} is negative.");
        else
            WriteLine($"The number {number} is zero.");
    }


    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
