using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        double[] p1 = Array.ConvertAll(ReadLine().Split(),double.Parse);
        double[] p2 = Array.ConvertAll(ReadLine().Split(), double.Parse);

        WriteLine(GetDistance(p1, p2).ToString("f3"));
    }

    static double GetDistance(double[] pointOne, double[] pointTwo)
    {
        const int x = 0, y = 1;

        double x0 = Math.Max(pointOne[x], pointTwo[x]) - Math.Min(pointOne[x], pointTwo[x]);
        double y0 = Math.Max(pointOne[y], pointTwo[y]) - Math.Min(pointOne[y], pointTwo[y]);

        x0 = Math.Pow(x0, 2);
        y0 = Math.Pow(y0, 2);

        return Math.Sqrt(x0 + y0);                  // Distance = Sqrt((x2-x1)^2+(y2-y1)^2)
    }
}