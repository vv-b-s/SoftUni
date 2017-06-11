using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        double people = ReadNum();
        double elevatorCAP = ReadNum();

        WriteLine(Math.Ceiling(people/elevatorCAP));
    }


    static double ReadNum()
    {
        string input = ReadLine();
        double output;
        double.TryParse(input, out output);
        return output;
    }
}
