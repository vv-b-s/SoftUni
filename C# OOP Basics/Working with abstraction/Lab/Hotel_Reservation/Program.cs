using System;
using System.Linq;

namespace Hotel_Reservation
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var price = PriceCalculator.CalculatePrice(
                pricePerDay: decimal.Parse(data[0]),
                reservedDays: int.Parse(data[1]),
                season: Enum.Parse<PriceMultiplier>(data[2]),
                discount: data.Length == 4 ? Enum.Parse<Discount>(data[3]) : Discount.None);

            Console.WriteLine(price.ToString("F2"));
        }
    }
}
