using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using static System.Console;

class Circle
{
    const int x = 0, y=1;

    private double[] center = new double[2];
    private double radius;

    public Circle(double centerX, double centerY, double radius)
    {
        center[x] = centerX;
        center[y] = centerY;
        this.radius = radius;
    }

    public bool Intersects(Circle circle)
    {
        double distance = GetDistance(center, circle.center);
        return distance <= radius + circle.radius;
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

class Program
{
    static void Main()
    {
        double[] circleData = Array.ConvertAll(ReadLine().Split(),double.Parse);
        var circle1 = new Circle(circleData[0], circleData[1], circleData[2]);
        circleData = Array.ConvertAll(ReadLine().Split(), double.Parse);
        var circle2 = new Circle(circleData[0], circleData[1], circleData[2]);

        WriteLine(circle1.Intersects(circle2) ? "Yes" : "No");
    }
}