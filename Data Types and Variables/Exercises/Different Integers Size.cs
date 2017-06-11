using System;
using System.Globalization;
using System.Reflection.Emit;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        string integer = ReadLine();
        var canFitIn = new StringBuilder();

        sbyte a;
        if (sbyte.TryParse(integer, out a))
            canFitIn.AppendLine("* sbyte");

        byte b;
        if (byte.TryParse(integer, out b))
            canFitIn.AppendLine("* byte");

        short c;
        if (short.TryParse(integer, out c))
            canFitIn.AppendLine("* short");

        ushort d;
        if (ushort.TryParse(integer, out d))
            canFitIn.AppendLine("* ushort");

        int e;
        if (int.TryParse(integer, out e))
            canFitIn.AppendLine("* int");

        uint f;
        if (uint.TryParse(integer, out f))
            canFitIn.AppendLine("* uint");

        long g;
        if (long.TryParse(integer, out g))
            canFitIn.AppendLine("* long");

        WriteLine(canFitIn.Length>0?
            $"{integer} can fit in:\n{canFitIn}":
            $"{integer} can't fit in any type");

    }

    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
