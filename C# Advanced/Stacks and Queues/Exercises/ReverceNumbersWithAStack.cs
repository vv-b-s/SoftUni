using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

class ReverceNumbersWithAStack
{
    static void Main(string[] args)
    {
        var numbers = new Stack<int>(ReadLine()
            .Split(' ').Where(n=>n!="").Select(int.Parse).ToArray());

        while (numbers.Count>0)
            Write(numbers.Pop()+" ");
        WriteLine();
    }
}
