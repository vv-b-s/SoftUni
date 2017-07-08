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
        var wormLength = double.Parse(ReadLine())*100;
        var wormWidth = double.Parse(ReadLine());

        var remainder = wormLength % wormWidth;
        WriteLine(remainder == 0||wormWidth==0||wormLength==0 ?
            (wormWidth * wormLength).ToString("f2") :
            (wormLength/wormWidth*100).ToString("f2")+"%");
    }
}
