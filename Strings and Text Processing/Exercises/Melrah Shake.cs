using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Program
{
    static void Main()
    {
        var text = new StringBuilder(ReadLine());
        var pattern = ReadLine();

        while(pattern.Length>0)
        {
            if (text.ToString().Contains(pattern))
            {
                text = text.Remove(text.ToString().IndexOf(pattern), pattern.Length);
                if (text.ToString().Contains(pattern))
                {
                    text.Remove(text.ToString().LastIndexOf(pattern), pattern.Length);
                    WriteLine("Shaked it.");
                }
                else
                {
                    WriteLine("No shake.");
                    break;
                }
            }
            else
            {
                WriteLine("No shake.");
                break;
            }

            pattern = pattern.Remove(pattern.Length / 2, 1);
        }
        if(pattern.Length==0)
            WriteLine("No shake.");

        WriteLine(text);
    }

}