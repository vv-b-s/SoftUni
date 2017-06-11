using System;
using System.Globalization;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        float distance = (float) ReadNum();
        float hours = (float)ReadNum(), minutes = (float) ReadNum(), seconds = (float) ReadNum();
        float[] time =
        {
            hours+minutes/60+seconds/3600,    //Time in hours
            seconds+hours*3600+minutes*60      // Time in minutes
        };

        WriteLine($"{distance/time[1]}\n" +
                  $"{distance/1000/time[0]}\n" +
                  $"{distance/1609/time[0]}");
    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
