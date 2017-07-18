using System;
using System.Text;
using System.Linq;
using static System.Console;

class Program
{
    static void Main()
    {
        WriteLine(ReverseNumbers(ReadLine()));
    }

    static string ReverseNumbers(string number)
    {
        char[] numbs = number.ToCharArray();
        Array.Reverse(numbs);

        bool isNegative = false;
        if(number.Contains('-'))
        {
            number.Remove(0, 1);
            isNegative = true;
        }
        return $"{(isNegative ? "-" : "")}{new string(numbs)}";

    }
}
