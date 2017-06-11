using System;
using System.Globalization;
using System.Text;
using static System.Console;

class Rectangle
{
    private double height, width, _perimeter, _area, _diagonal;

    internal double Perimeter => _perimeter;

    internal double Area => _area;

    internal double Diagonal => _diagonal;

    internal Rectangle(double height, double width)
    {
        this.height = height;
        this.width = width;

        _perimeter = 2 * height + 2 * width;
        _area = height * width;
        _diagonal =  Math.Sqrt(width * width + height * height);
    }
}

class Program
{
    static void Main()
    {
        Rectangle a = new Rectangle(ReadNum(),ReadNum());
        WriteLine($"{a.Perimeter}\n" +
                  $"{a.Area}\n" +
                  $"{a.Diagonal}");
    }

    static double ReadNum()
    {
        string input = ReadLine();
        double output;
        double.TryParse(input, out output);
        return output;
    }
}
