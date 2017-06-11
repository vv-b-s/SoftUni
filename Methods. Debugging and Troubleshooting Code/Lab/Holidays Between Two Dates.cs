using System;
using System.Globalization;
using static System.Console;

class HolidaysBetweenTwoDates
{
    static void Main()
    {
        string[] dates = { CorrectDate(ReadLine()), CorrectDate(ReadLine()) };

        var startDate = DateTime.ParseExact(dates[0],
            "dd.MM.yyyy", CultureInfo.InvariantCulture);
        var endDate = DateTime.ParseExact(dates[1],
            "dd.MM.yyyy", CultureInfo.InvariantCulture);
        var holidaysCount = 0;
        for (var date = startDate; DateTime.Compare(date,endDate)<=0; date = date.AddDays(1))
            if (date.DayOfWeek == DayOfWeek.Saturday ||
                date.DayOfWeek == DayOfWeek.Sunday) holidaysCount++;
        Console.WriteLine(holidaysCount);
    }

    static string CorrectDate(string date)
    {
        string[] dateElement = date.Split('.');
        for (int i = 0; i < dateElement.Length - 1; i++)
            if (dateElement[i].Length < 2)
                dateElement[i] = $"0{dateElement[i]}";
        return $"{dateElement[0]}.{dateElement[1]}.{dateElement[2]}";
    }
}
