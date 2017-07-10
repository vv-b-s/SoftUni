using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class Program
{
    static void Main()
    {
        var thing = new { ama = 5, panama = "hi"  };
        WriteLine(thing.panama);
    }
}
