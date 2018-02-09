using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var size = ReadLine().Split().Where(i => i != "").Select(long.Parse).ToArray();

        var input = "";
        var ivosPower = 0L;
        var evilSpots = new HashSet<string>();

        while ((input = ReadLine()) != "Let the Force be with you")
        {
            var ivoLocation = input.Split().Select(long.Parse).ToArray();
            var evilPower = ReadLine().Split().Select(long.Parse).ToArray();

            for (long i = evilPower[0], j = evilPower[1]; i >= 0; i--, j--)
                if(LocationIsInArray(i,j,size))
                    evilSpots.Add($"{i} {j}");

            for (long i = ivoLocation[0], j = ivoLocation[1]; i >= 0; i--, j++)
            {
                if (LocationIsInArray(i, j, size) && !evilSpots.Contains($"{i} {j}"))
                    ivosPower += GetStarPower(size[1], i, j);
            }

        }

        WriteLine(ivosPower);
    }

    private static long GetStarPower(long width, long rowIndex, long columnIndex) => width * rowIndex + columnIndex;

    private static bool LocationIsInArray(long i, long j, long[] dimensions) => i >= 0 && i < dimensions[0] && j >= 0 && j < dimensions[1];
}