using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int cent = (int) ReadNum();
        int years = cent * 100;
        int days = (int)(years * 365.2422);
        long hours = days * 24;
        long minutes = hours * 60;

        WriteLine($"{cent} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
    }


    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
