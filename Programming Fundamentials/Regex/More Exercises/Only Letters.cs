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
        var text = ReadLine();
        text = Regex.Replace(text, @"\d+(?=[^0-9])", "0");

        var chArray = text.ToCharArray();
        for (int i = 0; i < chArray.Length; i++)
            if (chArray[i] == '0')
                chArray[i] = chArray[i + 1];
        WriteLine(new string(chArray));
    }

    static string AddVar(string value)
    {
        var sB = new StringBuilder();
        sB.Append('{');
        sB.Append(value);
        sB.Append('}');
        return sB.ToString();
    }

}