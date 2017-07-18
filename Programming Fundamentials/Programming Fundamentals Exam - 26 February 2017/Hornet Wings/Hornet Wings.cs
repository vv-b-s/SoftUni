using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class File
{
    public string FileName { set; get; }
    public string Location { set; get; }
    public string Extension { set; get; }
    public long Size { set; get; }

class Program
{
    static void Main()
    {
        var wingFlaps = int.Parse(ReadLine());
        var distancePer1000flaps = double.Parse(ReadLine());
        var endurance = long.Parse(ReadLine());

        var distancePasses = wingFlaps / 1000 * distancePer1000flaps;
        long takenTime = wingFlaps / 100;
        var delay = wingFlaps / endurance * 5;
        takenTime += delay;

        WriteLine($"{distancePasses:f2} m.\n" +
            $"{takenTime} s.");
    }
}