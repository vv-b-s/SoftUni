using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var numberOfBoxes = int.Parse(Console.ReadLine());

        var boxes = new List<Box<string>>();
        while (numberOfBoxes-- > 0)
            boxes.Add(new Box<string>(Console.ReadLine()));

        var comparingBox = new Box<string>(Console.ReadLine());

        var numberOfGreaterBoxes = boxes.Count(b => b > comparingBox);

        System.Console.WriteLine(numberOfGreaterBoxes);
    }
}
