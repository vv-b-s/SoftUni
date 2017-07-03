using System;
using System.Globalization;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        string a = ReadLine();
        string b = ReadLine();
        WriteLine("Before:\n" +
                  $"a = {a}\n" +
                  $"b = {b}");
        SwitchPlaces(ref a, ref b);
        WriteLine("After:\n" +
                  $"a = {a}\n" +
                  $"b = {b}");
    }

    static void SwitchPlaces(ref string str1, ref string str2)
    {
        string temp = str1;
        str1 = str2;
        str2 = temp;
    }

}
