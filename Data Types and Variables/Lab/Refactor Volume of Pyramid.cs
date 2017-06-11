using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        Console.Write("Length: ");
        double length = ReadNum();
        Console.Write("Width: ");
        double width = ReadNum();
        Console.Write("Height: ");
        double height = ReadNum();
        double volume = (length * width * height) / 3;
        Console.WriteLine("Pyramid Volume: {0:F2}", volume);
    }


    static double ReadNum()
    {
        string input = ReadLine();
        double output;
        double.TryParse(input, out output);
        return output;
    }
}
