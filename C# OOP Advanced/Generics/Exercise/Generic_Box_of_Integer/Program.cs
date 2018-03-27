using System;

public class Program
{
    static void Main(string[] args)
    {
        var numberOfItems = int.Parse(Console.ReadLine());

        var box = new Box<int>();
        while(numberOfItems-->0)
            box.AddItems(int.Parse(Console.ReadLine()));
        
        System.Console.WriteLine(box);
    }
}