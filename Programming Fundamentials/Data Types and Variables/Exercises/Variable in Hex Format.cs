using System;
using System.Globalization;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int hexNumber = Convert.ToInt32(ReadLine(), 16);
        WriteLine(hexNumber);
    }

}
