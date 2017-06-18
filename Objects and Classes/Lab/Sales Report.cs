using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;

class Sale
{
    public decimal TotalSales { set; get; }

    public Sale( decimal productPrice, double productQuan)
    {
        AddProduct(productPrice, productQuan);
    }

    public void AddProduct(decimal productPrice, double productQuan) => TotalSales += productPrice * (decimal)productQuan;
        
}


class Program
{
    static void Main()
    {
        var TownSales = new SortedDictionary<string, Sale>();
        
        for(int i = int.Parse(ReadLine());i>0;i--)
        {
            string[] input = ReadLine().Split();
            string town = input[0];
            decimal price = decimal.Parse(input[2]);
            double quantity = double.Parse(input[3]);

            if (TownSales.ContainsKey(town))
                TownSales[town].AddProduct( price, quantity);
            else
                TownSales[town] = new Sale(price, quantity);
        }

        foreach (var town in TownSales)
            WriteLine($"{town.Key} -> {town.Value.TotalSales:f2}");
    }
}