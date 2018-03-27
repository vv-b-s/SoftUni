using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var numberOfElementsToAdd = int.Parse(Console.ReadLine());
        var boxes = new List<Box<string>>();
        while(numberOfElementsToAdd-->0)
            boxes.Add(new Box<string>(Console.ReadLine()));

        var swapIndexes = Console.ReadLine()
            .Split(" ",StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        
        Swap(boxes, swapIndexes[0],swapIndexes[1]);

        Console.WriteLine(string.Join(Environment.NewLine,boxes));
    }

    private static void Swap<TElement>(List<TElement> elements, int swapPosition1, int swapPosition2)
    {
        var tmp = elements[swapPosition1];
        elements[swapPosition1] = elements[swapPosition2];
        elements[swapPosition2] = tmp;
    }
}