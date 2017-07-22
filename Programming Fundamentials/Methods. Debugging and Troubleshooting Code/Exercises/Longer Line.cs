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
        double[][] points =
        {
            new[]{ (double)ReadNum(),(double)ReadNum()},
            new[]{ (double)ReadNum(),(double)ReadNum()},
            new[]{ (double)ReadNum(),(double)ReadNum()},
            new[]{ (double)ReadNum(),(double)ReadNum()}
        };

        double line1Length = GetDistance(points[0], points[1]);
        double line2Length = GetDistance(points[2], points[3]);

        string output;
        if (line1Length >= line2Length)
            output = points[0] == FindClosestToCenter(points[0], points[1]) ?
                $"({points[0][x]}, {points[0][y]})({points[1][x]}, {points[1][y]})" :
                $"({points[1][x]}, {points[1][y]})({points[0][x]}, {points[0][y]})";
        else
            output = points[2] == FindClosestToCenter(points[2], points[3]) ?
                $"({points[2][x]}, {points[2][y]})({points[3][x]}, {points[3][y]})" :
                $"({points[3][x]}, {points[3][y]})({points[2][x]}, {points[2][y]})";

        WriteLine(output);
    }

    static double[] FindClosestToCenter(double[] p1,double[] p2)
    {
        double[] center = { 0, 0 };

        double[] distanceToZero = { GetDistance(p1,center), GetDistance(p2,center) };

        return distanceToZero[0] <= distanceToZero[1] ? p1 : p2;
    }

    static double GetDistance(double[] pointOne,double[] pointTwo)
    {
        double x0 = Math.Max(pointOne[x], pointTwo[x]) - Math.Min(pointOne[x], pointTwo[x]);
        double y0 = Math.Max(pointOne[y], pointTwo[y]) - Math.Min(pointOne[y], pointTwo[y]);

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
