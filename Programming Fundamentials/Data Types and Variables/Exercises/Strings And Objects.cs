using System;
using System.Globalization;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        string strOne = ReadLine();
        string strTwo = ReadLine();

        WriteLine(string.Concat(strOne,' ',strTwo));
    }
}
