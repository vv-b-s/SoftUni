using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        decimal numOne = ReadNum();
        double numTwo = (double) ReadNum();
        decimal numThree = ReadNum();

        WriteLine($"{numOne}\n" +
                  $"{numTwo}\n" +
                  $"{numThree}\n");
    }


    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
