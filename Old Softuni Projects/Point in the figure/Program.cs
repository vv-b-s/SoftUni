using System;
using static System.Console;

class Program
{
    static void Main()
    {
        const sbyte x = 0, y = 1;
        int h = (int)ReadNum();
        int[] position = { (int)ReadNum(), (int)ReadNum() };

        if (position[y] >= 0 && position[y] <= 4 * h)
        {
            if ((position[x] == h || position[x] == 2 * h) && position[y] >= h)
                WriteLine("border");
            else if ((position[x] == 0 || position[x] == 3 * h) && position[y] < h)
                WriteLine("border");
            else if ((position[y] == 0 || position[y] == h) && position[x] >= 0 && position[x] <= h * 3)
            {
                if (position[x] >= h && position[x] <= h * 2 && position[y] != 0)               //If position x is bwtween the vertical and horisontal rectangle
                    WriteLine("inside");
                else
                    WriteLine("border");        //if not
            }
            else if ((position[y] == 0 || position[y] == h * 4) && position[x] >= h && position[x] <= h * 2)
                WriteLine("border");
            else if (position[x] > h && position[x] < h * 2 && position[y] >= h)
                WriteLine("inside");
            else if (position[x] > 0 && position[x] < h * 3 && position[y] < h)
                WriteLine("inside");
            else
                WriteLine("outside");
        }
        else
            WriteLine("outside");
    }
    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}

