using System;
using static System.Console;
using System.Globalization;

class Program
{
    static void Main()
    {
        string inputDate = ReadLine();
        CultureInfo cultInfo = CultureInfo.InvariantCulture;
        DateTime storedDate = DateTime.ParseExact(inputDate, "dd-MM-yyyy", cultInfo);
        WriteLine((storedDate.AddDays(999)).ToString("dd-MM-yyyy"));
    }
}