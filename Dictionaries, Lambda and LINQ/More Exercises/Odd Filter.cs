using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var numbers = ReadLine()
        .Split()
        .Select(int.Parse)
        .ToList();
        numbers.RemoveAll(n => n % 2 != 0);

        double average = numbers.Average();
        for (int i = 0; i < numbers.Count; i++)
            numbers[i] += numbers[i] > average ? 1 : -1;
        
        WriteLine(string.Join(" ",numbers));
    }
}