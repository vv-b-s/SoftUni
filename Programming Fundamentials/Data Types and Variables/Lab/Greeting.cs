using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        string[] name = {ReadLine(), ReadLine()};
        int age = (int) ReadNum();
        WriteLine($"Hello, {name[0]} {name[1]}. You are {age} years old.");
    }


    static double ReadNum()
    {
        string input = ReadLine();
        double output;
        double.TryParse(input, out output);
        return output;
    }
}
