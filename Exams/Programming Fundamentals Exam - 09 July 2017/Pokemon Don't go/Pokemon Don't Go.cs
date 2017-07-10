using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Program
{
    static void Main()
    {
        var integers = ReadLine().Split().Select(long.Parse).ToList();
        var sumOfRemovedElements = 0L;
        while (integers.Count>0)
        {
            int seqIndex = int.Parse(ReadLine());

            if (seqIndex >= 0 && seqIndex < integers.Count)
                sumOfRemovedElements += RemoveElement(integers, seqIndex);
            else if (seqIndex < 0)
            {
                var removedElement = RemoveElement(integers, 0);
                sumOfRemovedElements += removedElement;
                integers = integers.Skip(integers.Count-1).Concat(integers).ToList();
            }
            else if (seqIndex >= integers.Count)
            {
                var removedElement = RemoveElement(integers, integers.Count - 1);
                sumOfRemovedElements += removedElement;
                integers.Add(integers[0]);                
            }
        }

        WriteLine(sumOfRemovedElements);
    }

    private static long RemoveElement(List<long> integers, int seqIndex)
    {
        var removedElement = integers[seqIndex];
        integers.RemoveAt(seqIndex);
        for (int i = 0; i < integers.Count; i++)
        {
            if (integers[i] <= removedElement)
                integers[i] += removedElement;
            else if (integers[i] > removedElement)
                integers[i] -= removedElement;
        }
        return removedElement;
    }
}
