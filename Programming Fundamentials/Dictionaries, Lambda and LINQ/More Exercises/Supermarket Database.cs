using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using static System.Console;

class Program
{
    static void Main()
    {
        var Product = new Dictionary<string,List<decimal>>();

        string input;
        while ((input = ReadLine()) != "stocked")
        {
            string product = input.Split()[0];
            decimal price = decimal.Parse(input.Split()[1]);
            decimal quantity = decimal.Parse(input.Split()[2]);

            if (Product.ContainsKey(product))
            {
                Product[product][0] = price;
                Product[product][1] += quantity;
                Product[product][2] = Product[product][0] * Product[product][1];
            }
            else
                Product[product] = new List<decimal> {price, quantity, price * quantity};         
        }

        foreach (var product in Product)
            WriteLine($"{product.Key}: ${product.Value[0]:f2} * {product.Value[1]:f0} = ${product.Value[2]:f2}");
        WriteLine("------------------------------");
        WriteLine($"Grand Total: ${Product.Sum(p=>p.Value[2]):f2}");
    }
}