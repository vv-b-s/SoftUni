using System;

class PriceChangeAlert
{
    static void Main()
    {
        int    loopLength =     int.Parse (Console.ReadLine());
        double threshold  =  double.Parse (Console.ReadLine());
        double lastPrice  =  double.Parse (Console.ReadLine());

        for (int i = 0; i < loopLength-1 ; i++)
        {
            double price = double.Parse(Console.ReadLine());
            double ror   = RateOfReturn(lastPrice, price);
            Console.WriteLine(GenerateChangeMessage(price, lastPrice, ror, HasDifference(ror, threshold)));

            lastPrice = price;
        }
    }

    private static string GenerateChangeMessage(double price, double lastPrice, double ror, bool hasDifferance)
    {
        ror *= 100;
        string message = "";
        if (ror == 0)
            message = string.Format($"NO CHANGE: {price}");

        else if (!hasDifferance)
            message = string.Format($"MINOR CHANGE: {lastPrice} to {price} ({ror:F2}%)");

        else if (hasDifferance && (ror > 0))
            message = string.Format($"PRICE UP: {lastPrice} to {price} ({ror:F2}%)");

        else if (hasDifferance && (ror < 0))
            message = string.Format($"PRICE DOWN: {lastPrice} to {price} ({ror:F2}%)");

        return message;
    }
    private static bool HasDifference(double threshold, double isDiff) => Math.Abs(threshold) >= isDiff ? true : false;

    private static double RateOfReturn(double lastPrice, double price)=> (price - lastPrice) / lastPrice;
}
