using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var raw = ReadLine().Trim(' ').Split();
        RemoveEmptyCells(ref raw);

        var numbers = raw.Select(double.Parse).ToList();
        bool repetitiveNumbersContained;
        do
        {
            repetitiveNumbersContained = false;
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    numbers[i - 1] += numbers[i];
                    numbers.Remove(numbers[i]);
                    repetitiveNumbersContained = true;
                }
            }
        }
        while (repetitiveNumbersContained);

        WriteLine(string.Join(" ", numbers));
    }

    static void RemoveEmptyCells(ref string[] arr)
    {
        List<string> raw = arr.ToList();
        raw.RemoveAll(t => t == "");
        arr = raw.ToArray();
    }
}