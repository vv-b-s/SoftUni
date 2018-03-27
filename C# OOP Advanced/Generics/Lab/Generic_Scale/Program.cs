using System;

class Program
{
    static void Main(string[] args)
    {
        var number1 = 5;
        var number2 = 5;

        var scale = new Scale<int>(number1,number2);
        System.Console.WriteLine(scale.GetHeavier());
    }
}