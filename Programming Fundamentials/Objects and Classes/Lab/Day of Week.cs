using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using static System.Console;

class Program
{
    static void Main()
    {
        string dateInString = ReadLine();
        var day = DateTime.ParseExact(dateInString, "d-M-yyyy", CultureInfo.InvariantCulture);
        WriteLine(day.DayOfWeek);
    }
}