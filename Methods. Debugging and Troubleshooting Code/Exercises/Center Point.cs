using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    const int x = 0, y = 1;
    static void Main()
    {
        double[] centerPodouble = FindClosestToCenterPodouble((double)ReadNum(), (double)ReadNum(), (double)ReadNum(), (double)ReadNum());
        WriteLine($"({centerPodouble[x]}, {centerPodouble[y]})");
    }

    static double[] FindClosestToCenterPodouble(double x1, double y1, double x2, double y2)
    {

        double[] p1 = { x1, y1 };
        double[] p2 = { x2, y2 };

        double[] distanceToZero = { GetDistanceToZero(p1), GetDistanceToZero(p2) };

        return distanceToZero[0] <= distanceToZero[1] ? p1 : p2;
    }

    static double GetDistanceToZero(double[] podouble)
    {
        double x0 = Math.Max(podouble[x], 0) - Math.Min(podouble[x], 0);
        double y0 = Math.Max(podouble[y], 0) - Math.Min(podouble[y], 0);

        x0 = Math.Pow(x0, 2);
        y0 = Math.Pow(y0, 2);

        return Math.Sqrt(x0 + y0);                  // Distance = Sqrt((x2-x1)^2+(y2-y1)^2)
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
