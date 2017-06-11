using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        char[] key = { char.Parse(ReadLine()), char.Parse(ReadLine()) };
        char missLetter = char.Parse(ReadLine());

        for (char i = key[0]; i <= key[1]; i++)
            for (char j = key[0]; j <= key[1]; j++)
                for (char k = key[0]; k <= key[1]; k++)
                    if (i != missLetter && j != missLetter && k != missLetter)
                        Write(i + "" + j + "" + k + " ");
        WriteLine();
    }


    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}
