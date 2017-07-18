using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
class Cube
{
    public double CubeSide;

    public double Face   =>  Sqrt(2 * Pow(CubeSide,2));
    public double Space  =>  Sqrt(3 * Pow(CubeSide, 2));
    public double Volume =>  Pow(CubeSide, 3);
    public double Area   =>  Pow(CubeSide, 2) * 6;

    internal Cube(double cubeSide)
    {
        CubeSide = cubeSide;
    }
}

class Program
{
    static void Main()
    {
        Cube cuby = new Cube((double)ReadNum());
        string requiredSide = ReadLine();

        switch(requiredSide)
        {
            case "face":   WriteLine(Round(cuby.Face,2).ToString("f2"));    break;
            case "space":  WriteLine(Round(cuby.Space, 2).ToString("f2"));  break;
            case "volume": WriteLine(Round(cuby.Volume, 2).ToString("f2")); break;
            case "area":   WriteLine(Round(cuby.Area, 2).ToString("f2"));   break;
        }
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
