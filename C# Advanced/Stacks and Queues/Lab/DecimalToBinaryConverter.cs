using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

class DecimalToBinaryConverter
{
    static void Main()
    {
        int decNum = int.Parse(ReadLine());

        var bin = new Stack<string>();

        if (decNum == 0)
        {
            WriteLine(0);
            return;
        }

        while (decNum > 0)
        {
            int remainder = decNum % 2;
            if (remainder == 0)
                bin.Push(0 + "");
            else
                bin.Push(1 + "");

            decNum = (decNum - remainder) / 2;
        }

        var sB = new StringBuilder();
        while (bin.Count > 0)
            sB.Append(bin.Pop());
        WriteLine(sB.ToString());
    }
}
