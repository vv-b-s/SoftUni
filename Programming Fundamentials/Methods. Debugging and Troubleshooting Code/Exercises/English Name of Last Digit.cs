using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        WriteLine(LastDigit(ReadLine()));
    }

    static string LastDigit(string number)
    {
        switch(number[number.Length-1])
        {
            case '0': return "zero";
            case '1': return "one";
            case '2': return "two";
            case '4': return "four";
            case '5': return "five";
            case '6': return "six";
            case '7': return "seven";
            case '8': return "eight";
            case '9': return "nine";
        }
        return null;
    }
}
