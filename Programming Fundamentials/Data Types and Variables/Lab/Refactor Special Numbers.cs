using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int number = (int) ReadNum();
        int sum = 0;
        for (int num = 1; num <= number; num++)
        {
            sum += num / 10;
            sum += num % 10;
            WriteLine($"{num} -> {(sum == 5) || (sum == 7) || (sum == 11)}");
            sum = 0;
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
