using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientsInput = Console.ReadLine();
            var productsInput = Console.ReadLine();

            var clients = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();

            try
            {
                //Feed the clients list
                GetObjects(clientsInput, clients, (n, m) => new Person(n, m));

                //Feed the products list
                GetObjects(productsInput, products, (n, m) => new Product(n, m));
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return; }

            var input = "";
            while((input = Console.ReadLine())!="END")
            {
                var data = input.Split();
                var personName = data[0];
                var productName = data[1];

                var productBought = clients[personName].BuyProduct(products[productName]);

                Console.WriteLine(productBought ?
                    $"{personName} bought {productName}" :
                    $"{personName} can't afford {productName}");
            }

            Console.WriteLine(string.Join(Environment.NewLine, clients.Values));
        }

        /// <summary>
        /// Assign the values to the given list
        /// https://stackoverflow.com/questions/1852837/is-there-a-generic-constructor-with-parameter-constraint-in-c
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="input"></param>
        /// <param name="feedingList"></param>
        /// <param name="addition"></param>
        private static void GetObjects<TObject>(string input, Dictionary<string, TObject> feedingList, Func<string, decimal,TObject> addition)
        {
            var pairs = ExtractPairs(input);

            while (pairs.Count>0)
            {
                (string name, decimal money) = pairs.Dequeue();

                feedingList[name] = addition(name, money);
            }
        }

        /// <summary>
        /// Ecxtract the values of the input coresponding to a name and a price
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static Queue<(string name, decimal money)> ExtractPairs(string input) => new Queue<(string, decimal)>(Regex
            .Matches(input, @"(?<name>[\w\s]+)?=(?<money>-?\d+(\.\d+)?);?")
            .Select(m => (m.Groups["name"].Value, decimal.Parse(m.Groups["money"].Value))));
    }
}
