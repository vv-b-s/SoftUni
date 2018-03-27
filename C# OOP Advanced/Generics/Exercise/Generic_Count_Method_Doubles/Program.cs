using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var numberOfBoxes = int.Parse(Console.ReadLine());

        var boxes = new List<Box<double>>();
        while (numberOfBoxes-- > 0)
            boxes.Add(new Box<double>(double.Parse(Console.ReadLine())));

        var comparingBox = new Box<double>(double.Parse(Console.ReadLine()));

        var numberOfGreaterBoxes = boxes.Count(b => b > comparingBox);

        System.Console.WriteLine(numberOfGreaterBoxes);
    }
}
