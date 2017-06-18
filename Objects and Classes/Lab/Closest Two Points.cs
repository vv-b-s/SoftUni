using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static void Main()
    {
        var distances = new Dictionary<List<string>, double>();
        double[][] p = new double[int.Parse(ReadLine())][];

        for(int i=0;i<p.Length;i++)
            p[i] = Array.ConvertAll(ReadLine().Split(), double.Parse);
        
         for(int i=0;i<p.Length;i++)
            for(int j=i+1;j<p.Length;j++)
                distances.Add(
                    new List<string> {$"({p[i][0]}, {p[i][1]})", $"({p[j][0]}, {p[j][1]})"},
                                        GetDistance(p[i], p[j]));

        var MinDistance = distances.Where(d => d.Value == distances.Values.Min()).ToDictionary(k=>k.Key,v=>v.Value);
        WriteLine(MinDistance.First().Value.ToString("f3") + "\n" + string.Join("\n", MinDistance.First().Key));
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