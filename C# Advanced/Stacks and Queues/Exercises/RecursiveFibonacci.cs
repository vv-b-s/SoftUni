using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

class RecursiveFibonacci
{ 
    static void Main(string[] args)
    {
        WriteLine(GetFibonacci(int.Parse(ReadLine())));
    }

    private static long GetFibonacci(long n,long a=1,long b=1)
    {
        if (n <= 2)
            return a;
        
        return GetFibonacci(n-1,a+b,a);
    }
}