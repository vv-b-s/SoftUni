using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

class ReverseStrings
{
    static void Main()
    {
        string input = ReadLine();

        var chars = new Stack<char>();
        foreach (var c in input)
            chars.Push(c);

        //Using StringBuilder instead of calling Console.Write every time would make printing faster
        var sB = new StringBuilder();

        //We can either take the last length of the stack and use it in a for loop or check when the stack is empty and stop looping by using a while loop
        while (chars.Count > 0)
            sB.Append(chars.Pop());

        WriteLine(sB.ToString());
    }
}
