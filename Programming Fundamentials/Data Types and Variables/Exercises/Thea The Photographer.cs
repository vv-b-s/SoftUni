using System;
using System.Globalization;
using System.Reflection.Emit;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        ulong numberOfPics = (ulong) ReadNum();
        decimal filterTime = ReadNum();
        ulong uploadableIMG = (ulong) Math.Ceiling(ReadNum() / 100 * numberOfPics);
        decimal timeNeededToUpload = ReadNum();

        decimal neededTime = numberOfPics * filterTime + uploadableIMG * timeNeededToUpload;

        uint days = (uint)(neededTime / 86400);
        neededTime -= (decimal)days * 86400;
        uint hours = (uint) (neededTime / 3600);
        neededTime -= (decimal)hours * 3600;
        uint minutes = (uint) (neededTime / 60);
        neededTime -= (decimal)minutes * 60;
        uint seconds = (uint) Math.Round(neededTime);

        WriteLine($"{days}:{hours:d2}:{minutes:d2}:{seconds:d2}");

    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
