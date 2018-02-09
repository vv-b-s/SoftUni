using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var masters = new Queue<string>();
        var knights = new Queue<string>();
        var padawans = new Queue<string>();

        var slavsAndToshkos = new Queue<string>();

        var yodaHasShown = false;

        int numberOfLines = int.Parse(ReadLine());

        while (numberOfLines-- > 0)
        {
            var input = ReadLine().Split().Where(i => i != "").ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains("m"))
                    masters.Enqueue(input[i]);

                if (input[i].Contains("k"))
                    knights.Enqueue(input[i]);

                if (input[i].Contains("p"))
                    padawans.Enqueue(input[i]);

                if (input[i].Contains("y"))
                {
                    yodaHasShown = true;
                }

                if (input[i].Contains("s") || input[i].Contains("t"))
                    slavsAndToshkos.Enqueue(input[i]);
            }
        }

        if (!yodaHasShown)
            foreach (var sOrT in slavsAndToshkos)
                Write(sOrT + " ");

        foreach (var master in masters)
            Write(master + " ");

        foreach (var knight in knights)
            Write(knight + " ");

        if (yodaHasShown)
            foreach (var sOrT in slavsAndToshkos)
                Write(sOrT + " ");

        foreach (var padawan in padawans)
            Write(padawan + " ");

        WriteLine();

    }
}