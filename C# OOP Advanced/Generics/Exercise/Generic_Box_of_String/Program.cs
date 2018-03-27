using System;

public class Program
{
    static void Main(string[] args)
    {
        var numberOfItems = int.Parse(Console.ReadLine());

        var box = new Box<string>();
        while(numberOfItems-->0)
            box.AddItems(Console.ReadLine());
        
        System.Console.WriteLine(box);
    }
}