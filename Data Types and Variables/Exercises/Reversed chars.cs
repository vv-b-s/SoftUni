using System;
using System.Globalization;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        char[] threeChars = new char[3];
        for(int i=0;i<3;i++)
            threeChars[i] = char.Parse(ReadLine());
        Array.Reverse(threeChars);
        WriteLine(new string(threeChars));
    }

}
