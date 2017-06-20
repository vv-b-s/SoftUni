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
        var date1 = DateTime.ParseExact(ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
        var date2 = DateTime.ParseExact(ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

        long numberOfWorkdays = 0;
        
        var Holidays = new List<DateTime>
        {
            new DateTime(2000,1,1),
            new DateTime(2000,3,3),
            new DateTime(2000,5,1),
            new DateTime(2000,5,6),
            new DateTime(2000,5,24),
            new DateTime(2000,9,6),
            new DateTime(2000,9,22),
            new DateTime(2000,11,1),
            new DateTime(2000,12,24),
            new DateTime(2000,12,25),
            new DateTime(2000,12,26)
        };

        for (var i = date1; i <= date2; i = i.AddDays(1))
            if (i.DayOfWeek != DayOfWeek.Saturday &&
                i.DayOfWeek != DayOfWeek.Sunday && 
                !Holidays.Any(h => h.Day == i.Day && h.Month == i.Month))
                numberOfWorkdays++;
        WriteLine(numberOfWorkdays);
    }
}