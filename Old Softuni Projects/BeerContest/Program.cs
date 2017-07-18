using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int rounds = (int)ReadNum();

        string[] round = new string[rounds];
        for (int i = 0; i < rounds; i++)
            round[i] = ReadLine();

        int Mitko = 0;
        int Vladko = 0;

        for (int i = 0; i < round.Length; i++)
        {
            if (round[i].Length % 2 == 0)
            {
                for (int j = 0; j < round[i].Length / 2; j++)
                    Mitko += (int)char.GetNumericValue(round[i][j]);
                for (int j = round[i].Length / 2; j < round[i].Length; j++)
                    Vladko += (int)char.GetNumericValue(round[i][j]);
            }
            else if (round[i].Length % 2 != 0)
            {
                for (int j = 0; j < round[i].Length / 2 + 1; j++)
                    Mitko += (int)char.GetNumericValue(round[i][j]);
                for (int j = round[i].Length / 2; j < round[i].Length; j++)
                    Vladko += (int)char.GetNumericValue(round[i][j]);
            }
        }

        if (Mitko > Vladko)
            WriteLine($"M {Mitko - Vladko}");
        else if (Mitko < Vladko)
            WriteLine($"V {Vladko - Mitko}");
        else
            WriteLine($"No {Vladko + Mitko}");
    }


    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}