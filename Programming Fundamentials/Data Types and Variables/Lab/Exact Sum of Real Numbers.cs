using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int numsToSum = (int) ReadNum();
        decimal sum=0;
        for (int i = 0; i < numsToSum; i++)
            sum += decimal.Parse(ReadLine());
        WriteLine(sum);

    }


    static double ReadNum()
    {
        string input = ReadLine();
        double output;
        double.TryParse(input, out output);
        return output;
    }
}
