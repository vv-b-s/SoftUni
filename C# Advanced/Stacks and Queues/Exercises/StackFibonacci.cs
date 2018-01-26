using System;
using System.Collections.Generic;
using static System.Console;

class StackFibbonacci
{
    static void Main(string[] args)
    {
        WriteLine(Fib(int.Parse(ReadLine())));
    }

    static long Fib(int end)
    {
        end--;
        var fibStack = new Stack<long>(new long[] { 0, 1 });
        while(end-- > 0)
        {
            var previousNumber = fibStack.Pop();
            var nextNumber = previousNumber + fibStack.Peek();
            fibStack.Push(previousNumber);
            fibStack.Push(nextNumber);
        }
        return fibStack.Pop();
    }
}
