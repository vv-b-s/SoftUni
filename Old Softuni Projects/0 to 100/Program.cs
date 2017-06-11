using System;
using static System.Console;

class Program
{
    static void Main()
    {

        // Human - non lazy version
        string[] singleNM = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        string[] tens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        string[] over10 = { "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety", "one hundred" };

        string input = ReadLine();
        int number = int.Parse(input);

        if (number < 10 && number >= 0)
            WriteLine(singleNM[number]);
        if (number >= 10 && number < 20)
            WriteLine(tens[number - 10]);
        if (number >= 20 && number < 100 && number % 10 == 0)
            WriteLine(over10[(number / 10) - 2]);
        else if (number >= 20 && number < 100)
            WriteLine(over10[(number / 10) - 2] + " " + singleNM[number % 10]);
        else if (number == 100)
            WriteLine(over10[8]);
        else if (number > 100 || number < 0)
            WriteLine("invalid number");


    }
}
