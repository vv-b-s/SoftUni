using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class  KnightsOfHonor
{
    public static void Main(string[] args)
    {
        Action<string> printNames = names =>
        {
            Write("Sir ");
            WriteLine(string.Join("\nSir ", names.Split().Where(name => name != "")));
        };

        printNames(ReadLine());
    }
}