using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class CustomComparator
{
    public static void Main(string[] args)
    {
        var numbers = ReadLine().Split().Select(int.Parse).ToArray();
        Array.Sort(numbers, Comparator);
        WriteLine(string.Join(" ",numbers));
    }

    private static int Comparator(int number1, int number2)
    {
        //If both numbers are even or odd
        if(number1%2==0&&number2%2==0||number1%2!=0&&number2%2!=0)
        {
            if (number1 == number2)
                return 0;
            else if (number1 > number2)
                return 1;
            else
                return -1;
        }
        else
        {
            if (number2 % 2 != 0)
                return -1;
            else
                return 1;
        }
    }
}