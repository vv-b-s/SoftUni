using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using static System.Console;

class Products
{
    public Dictionary<string, decimal> ProductPrice { set; get; }

    public Products(List<string> rawProductData)
    {
        ProductPrice = new Dictionary<string, decimal>();

        foreach (var rawProduct in rawProductData)
        {
            string product = rawProduct.Split('-')[0];
            decimal price = decimal.Parse(rawProduct.Split('-')[1]);
            ProductPrice[product] = price;
        }
    }
}

class Client
{
    public string Name { set; get; }
    public Dictionary<string, int> ProductNameAmount { set; get; }

    public Client(string name)
    {
        Name = name;
        ProductNameAmount = new Dictionary<string, int>();
    }

    public void AddProduct(string productAmount)
    {
        string productName = productAmount.Split(',')[0];
        int amount = int.Parse(productAmount.Split(',')[1]);

        if (ProductNameAmount.ContainsKey(productName))
            ProductNameAmount[productName] += amount;
        else
            ProductNameAmount[productName] = amount;
    }
}

class Receipt
{
    List<Client> clients;
    Products products;

    public Receipt(List<Client> clients, List<string> rawProducts)
    {
        this.clients = clients.OrderBy(c => c.Name).ToList();
        products = new Products(rawProducts);
    }

    public string PrintReceipt()
    {
        var receipt = new StringBuilder();
        decimal total = 0;
        foreach (var client in clients)
        {
            var productPrice = products.ProductPrice
                .Where(p => client.ProductNameAmount.ContainsKey(p.Key))
                .OrderBy(p=>p.Key)
                .ToDictionary(k => k.Key, v => Math.Round(v.Value * client.ProductNameAmount[v.Key], 2));

            if (productPrice.Count == 0)
                continue;

            receipt.AppendLine(client.Name);
            foreach (var item in productPrice)
                receipt.AppendLine($"-- {item.Key} - {client.ProductNameAmount[item.Key]}");
            receipt.AppendLine($"Bill: {productPrice.Values.Sum():f2}");
            total += productPrice.Values.Sum();
        }
        receipt.AppendLine($"Total bill: {Math.Round(total, 2):f2}");
        return receipt.ToString();
    }
}

class Program
{
    static void Main()
    {
        var clients = new List<Client>();
        var products = new List<string>();

        for (int i = int.Parse(ReadLine()); i > 0; i--)
            products.Add(ReadLine());

        string input;
        while ((input = ReadLine()) != "end of clients")
        {
            string[] raw = input.Split('-');

            bool newClient = true;
            foreach (var client in clients)
                if (client.Name == raw[0])
                {
                    client.AddProduct(raw[1]);
                    newClient = false;
                }
            if (newClient)
            {
                clients.Add(new Client(raw[0]));
                clients.Last().AddProduct(raw[1]);
            }
        }

        var receipt = new Receipt(clients, products);
        Write(receipt.PrintReceipt());
    }
}