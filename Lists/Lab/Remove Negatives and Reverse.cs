using System;
using System.Linq;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var integers = ReadLine().Split().Select(int.Parse).ToList();
        integers.RemoveAll(t => t < 0);
        integers.Reverse();

        WriteLine(integers.Count > 0 ?
                String.Join(" ", integers) :
                "empty");
    }

}