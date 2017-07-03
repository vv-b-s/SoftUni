using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int range = (int) ReadNum();
        for (char i = 'a'; i < 'a' + range; i++)
        {
            for(char j = 'a';j<'a'+range;j++)
                for(char k= 'a';k<'a'+range;k++)
                    WriteLine($"{(char)i}{(char)j}{(char)k}");
            WriteLine();
        }
    }


    static double ReadNum()
    {
        string input = ReadLine();
        double output;
        double.TryParse(input, out output);
        return output;
    }
}
