using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class AppliedArithmetics
{
    public static void Main(string[] args)
    {
        var numbers = ReadLine().Split(' ').Select(int.Parse).ToArray();

        string command;
        while((command=ReadLine())!="end")
        {
            if (command == "add")
                RefSelect(numbers, number => ++number);
            if (command == "subtract")
                RefSelect(numbers, number => --number);
            if (command == "multiply")
                RefSelect(numbers, number => number * 2);
            if (command == "print")
                WriteLine(string.Join(" ", numbers));                
        }
    }

    private static void RefSelect<TType>(TType[] array, Func<TType,TType> operation)
    {
        for (int i = 0; i < array.Length; i++)
            array[i] = operation(array[i]);
    }
}