using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    public static void Main(string[] args)
    {

        var nameLimit = int.Parse(ReadLine());

        var chosenName = ReadLine().Split().Where(name => name.ToCharArray().Sum(c => (int)c) >= nameLimit).FirstOrDefault();

        WriteLine(chosenName);
    }

}