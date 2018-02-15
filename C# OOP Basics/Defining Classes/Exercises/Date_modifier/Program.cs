using System;
using static System.Console;

namespace Date_modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var date1 = ReadLine();
            var date2 = ReadLine();

            WriteLine(DateModifier.GetDateDifferences(date1, date2));
        }
    }
}
