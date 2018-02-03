using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class Program
{
    public static void Main(string[] args)
    {
       bool Min(int number1, int number2) => number2 < number1;
        var numbers = new HashSet<int>(ReadLine().Split().Where(n => n != "").Select(int.Parse));

        GetNumber(numbers, Min);
    }

    private static void GetNumber(HashSet<int> numbers, Func<int, int, bool> Comparer)
    {
        var outputNumber = numbers.First();
        foreach(var number in numbers)
        {
            if (Comparer(outputNumber, number))
                outputNumber = number;
        }

        WriteLine(outputNumber);
    }
}