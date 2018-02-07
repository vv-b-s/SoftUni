using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    private static int cubeDimensions;
    static void Main()
    {
        cubeDimensions = int.Parse(ReadLine());
        var hitParts = new List<long>();

        var input = "";
        while ((input = ReadLine()) != "Analyze")
        {
            var digits = input.Split().Where(i => i != "").Select(long.Parse).ToArray();
            var pos = new long[] { digits[0], digits[1], digits[2] };

            if (PositionIsInCube(pos))
                hitParts.Add(digits[3]);
        }

        var cubeSum = hitParts.Count > 0 ? hitParts.Sum() : 0;
        var nonAffectedCells = Math.Pow(cubeDimensions,3)-hitParts.Where(p=>p!=0).ToList().Count;

        WriteLine(cubeSum + "\n" + nonAffectedCells);
    }

    private static bool PositionIsInCube(long[] pos) => pos.All(p => p >= 0 && p < cubeDimensions);

}
