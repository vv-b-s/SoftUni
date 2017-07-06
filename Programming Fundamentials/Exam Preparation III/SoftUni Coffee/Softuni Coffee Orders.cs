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
        var totalPrice = 0m;
        for(int i=int.Parse(ReadLine());i>0;i--)
        {
            var pricePerCapsule = decimal.Parse(ReadLine());
            var orderDate = DateTime.ParseExact(ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
            var capsulesCount = int.Parse(ReadLine());

            var orderPrice = pricePerCapsule * capsulesCount * DateTime.DaysInMonth(orderDate.Year, orderDate.Month);

            WriteLine($"The price for the coffee is: ${Math.Round(orderPrice,2):f2}");
            totalPrice += orderPrice;
        }

        WriteLine($"Total: ${Math.Round(totalPrice,2):f2}");
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