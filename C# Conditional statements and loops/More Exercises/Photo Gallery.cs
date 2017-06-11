using System;
using static System.Console;

class Program
{
    enum SizeLabel {B, KB, MB}
    static void Main()
    {
        int fileName = int.Parse(ReadLine());
        int[] date = { int.Parse(ReadLine()), int.Parse(ReadLine()), int.Parse(ReadLine()) };
        int[] time = { int.Parse(ReadLine()), int.Parse(ReadLine()) };
        double size = double.Parse(ReadLine());
        int[] res = { int.Parse(ReadLine()), int.Parse(ReadLine()) };
        string orientation;

        if (res[0] > res[1])
            orientation = "landscape";
        else if (res[0] < res[1])
            orientation = "portrait";
        else
            orientation = "square";

        SizeLabel sizeLB;
        if (size < 1000)
            sizeLB = SizeLabel.B;
        else if (size >= 1000 && size < 1000000)
        {
            sizeLB = SizeLabel.KB;
            size /= 1000;
        }
        else
        {
            sizeLB = SizeLabel.MB;
            size /= 1000000;
        }



        WriteLine($"Name: DSC_{fileName:d4}.jpg\n" +
            $"Date Taken: {date[0]:d2}/{date[1]:d2}/{date[2]} {time[0]:d2}:{time[1]:d2}\n" +
            $"Size: {Math.Round(size, 1)}{sizeLB.ToString()}\n" +
            $"Resolution: {res[0]}x{res[1]} ({orientation})");
    }
}
