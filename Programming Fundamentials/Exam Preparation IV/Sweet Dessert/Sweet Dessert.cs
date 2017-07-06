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
        var cash = decimal.Parse(ReadLine());
        var numberOfGuests = int.Parse(ReadLine());
        var bananasPrice = decimal.Parse(ReadLine())*2;
        var eggPrice = decimal.Parse(ReadLine())*4;
        var berryPrice = decimal.Parse(ReadLine())*0.2m;

        var setsOfPortionsNeeded = Math.Ceiling(numberOfGuests / 6m);

        var neededMoney = decimal.Round(setsOfPortionsNeeded * (bananasPrice + eggPrice + berryPrice),2);
        WriteLine(neededMoney > cash ?
            $"Ivancho will have to withdraw money - he will need {neededMoney - cash:f2}lv more." :
            $"Ivancho has enough money - it would cost {neededMoney:f2}lv.");
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