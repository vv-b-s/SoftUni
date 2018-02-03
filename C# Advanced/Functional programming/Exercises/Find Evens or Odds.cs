using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class FindEvensOrOdds
{
    public static void Main(string[] args)
    {
        var range = ReadLine().Split().Select(int.Parse).ToArray();
        var command = ReadLine();

        var numbers = Enumerable.Range(range[0], range[1]-range[0]+1);

        if (command == "odd")
            PrintNumbers(numbers, number => number % 2 != 0);
        else
            PrintNumbers(numbers, number => number % 2 == 0);
    }

    private static void PrintNumbers(IEnumerable<int> numbers, Predicate<int> filter)
    {
        var sB = new StringBuilder();
        foreach(var number in numbers)
        {
            if (filter(number))
                sB.Append(number + " ");
        }

        WriteLine(sB.ToString());
    }
}