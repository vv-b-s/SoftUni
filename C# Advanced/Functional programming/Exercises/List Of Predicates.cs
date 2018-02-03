using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class ListOfPredicates
{
    public static void Main(string[] args)
    {
        int.TryParse(ReadLine(), out int endOfNumberSequence);

        if (endOfNumberSequence < 0)
            return;

        var numbers = new Queue<int>(Enumerable.Range(1, endOfNumberSequence));

        //Get the sequence into a hashset to distinct repeating numbers and reverse it to speed up comparison
        var compareSequence = new HashSet<int>(ReadLine()
            .Split()
            .Select(int.Parse)
            .OrderByDescending(n => n));

        bool numberIsDivisible(int number1, int number2) => number1 % number2 == 0;

        foreach (var diviser in compareSequence)
        {
            var numbersLength = numbers.Count();
            for (int i = 0; i < numbersLength; i++)
            {
                var number = numbers.Dequeue();
                if (!numberIsDivisible(number, diviser))
                    continue;
                numbers.Enqueue(number);
            }
        }

        WriteLine(string.Join(" ", numbers));
    }
}