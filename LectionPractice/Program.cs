using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int size = (int)ReadNum();

        int LeftRight = size / 2 - 1;
        int middle = 0;

        for(int i=0;i<size/2;i++)
        {
            WriteLine("{0}#{1}#{0}", new string('.', LeftRight), new string('.', middle));
            LeftRight--;
            middle += 2;
        }
        LeftRight++;
        middle -= 2;

        for(int i=0;i<size/4;i++)
        {
            WriteLine("{0}#{1}#{0}", new string('.', LeftRight), new string('.', middle));
            LeftRight++;
            middle -= 2;
        }
        WriteLine(new string('-', size));
        int middleLeft = size / 2,middleRight = size/2;
        LeftRight = 0;
        for(int i=0;i<size/2;i++)
        {
            WriteLine("{0}{1}{2}{0}",new string('.',LeftRight),new string('\\',middleLeft),new string('/',middleRight));
            middleRight--;
            middleLeft--;
            LeftRight++;
        }
    }


    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}