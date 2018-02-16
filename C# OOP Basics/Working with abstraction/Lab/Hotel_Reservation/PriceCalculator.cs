using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_Reservation
{
    public enum PriceMultiplier { Autumn = 1, Spring, Winter, Summer }
    public enum Discount { None, SecondVisit = 10, VIP = 20 }
    class PriceCalculator
    {
        public static decimal CalculatePrice(decimal pricePerDay, int reservedDays, PriceMultiplier season, Discount discount = Discount.None) =>
            pricePerDay * reservedDays * (int)season * (1 - (decimal)discount/100);
    }
}
