using System;
using System.Globalization;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        char input = char.Parse(ReadLine());

        if(input>='0'&&input<='9')
            WriteLine("digit");
        else if (input == 'a' || input == 'e' || input == 'i' || input == 'o' || input == 'u'||
                 input == 'A' || input == 'E' || input == 'I' || input == 'O' || input == 'U')
                WriteLine("vowel");
        else
            WriteLine("other");
    }
}
