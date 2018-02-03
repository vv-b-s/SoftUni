using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class ActionPrint
{
    public static void Main(string[] args)
    {
        Action<string> PrintNameOnNewLine = names => WriteLine(string.Join("\n",names.Split().Where(name => name != "")));

        PrintNameOnNewLine(ReadLine());
    }
}