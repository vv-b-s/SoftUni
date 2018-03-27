using System;

public class Program
{
    static void Main(string[] args)
    {
        var box = new Box<string>("Hello world");
        var box2 = new Box<int>(123,456);

        System.Console.WriteLine(box);
        System.Console.WriteLine(box2); 
    }
}