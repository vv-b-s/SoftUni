using System;
using static System.Console;

class Program
{
    static void Main()
    {
        double BPM = double.Parse(ReadLine());
        double Beats = double.Parse(ReadLine());

        double bars = Beats / 4d;

        int seconds = (int)(60/(BPM/Beats));
        int minutes = seconds / 60;
        seconds -= minutes * 60;

        WriteLine($"{Math.Round(bars,1)} bars - {minutes}m {seconds}s");

    }
}
