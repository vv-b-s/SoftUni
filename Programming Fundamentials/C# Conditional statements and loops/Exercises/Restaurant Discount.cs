using System;
using static System.Console;

class Program
{
    enum Hall { smallHall, terrace, greatHall}
    enum Pack { Normal, Gold, Platinum}
    static void Main()
    {

        int[] hallPrices = { 2500, 5000, 7500 };
        int[] packPrice = { 500, 750, 1000 };
        double[] packDisocunt = { 0.95, 0.9, 0.85 };

        int groupSize = int.Parse(ReadLine());
        Pack pack = (Pack)Enum.Parse(typeof(Pack),ReadLine());

        string HallName;
        Hall hall;
        if (groupSize <= 50)
        {
            HallName = "Small Hall";
            hall = 0;
        }
        else if (groupSize >= 51 && groupSize <= 100)
        {
            HallName = "Terrace";
            hall = (Hall)1;
        }
        else if(groupSize >= 101 && groupSize <= 120)
        {
            HallName = "Great Hall";
            hall = (Hall)2;
        }
        else
        {
            WriteLine("We do not have an appropriate hall.");
            return;
        }

        double price = ((hallPrices[(int)hall] + packPrice[(int)pack]) * packDisocunt[(int)pack])/(double)groupSize;
        WriteLine($"We can offer you the {HallName}\n" +
            $"The price per person is {Math.Round(price, 2):f2}$");
    }
}
