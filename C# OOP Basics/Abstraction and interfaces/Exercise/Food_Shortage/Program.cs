using System;
using System.Collections.Generic;
using System.Linq;

namespace Food_Shortage
{
    class Program
    {
        static void Main(string[] args)
        {
            var buyers = new Dictionary<string, IBuyer>();

            var numberOfBuyers = int.Parse(Console.ReadLine());

            while (numberOfBuyers-- > 0)
            {
                var buyer = BuyerFacrory.Manufacture(Console.ReadLine().Split());
                var buyerName = ((Human)buyer).Name;

                buyers[buyerName] = buyer;
            }

            var input = "";
            while((input=Console.ReadLine())!="End")
            {
                if (buyers.ContainsKey(input))
                    buyers[input].BuyFood();
            }

            Console.WriteLine(buyers.Values.Sum(b => b.BoughtFood));
        }
    }
}
