using System;

public class Program
{
    static void Main(string[] args)
    {
        var list = new RandomList() { "Hello", "Olla", "Asta la", "Vista la" };
        Console.WriteLine(list.RandomString());
    }
}