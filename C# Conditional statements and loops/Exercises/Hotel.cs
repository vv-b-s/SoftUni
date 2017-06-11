using System;
using static System.Console;

class Program
{
    [Flags]
    enum Months { May, October = 0, June, September = 1, July = 2, August = 2, December = 2 }
    enum Room { Studio, Double, Suite }
    static void Main()
    {
        int[,] RoomPrice_Month =
        {
            { 50,60,68 },
            { 65,72,77 },
            { 75,82,89 }
        };
        double[] discount = { 0.95, 0.90, 0.85 };

        Months month;
        string _month = ReadLine();
        Enum.TryParse(_month, out month);
        int nights = int.Parse(ReadLine());

        double[] prices = new double[3];
        if (nights > 7 && month == (Months)0)
        {
            prices[(int)Room.Studio] = (_month == "October" ? nights - 1 : nights) * RoomPrice_Month[(int)Room.Studio, (int)month] * discount[(int)month];
            prices[(int)Room.Double] = nights * RoomPrice_Month[(int)Room.Double, (int)month];
            prices[(int)Room.Suite] = nights * RoomPrice_Month[(int)Room.Suite, (int)month];
        }
        else if (nights > 14 && (month == (Months)1 || month == (Months)2))
        {
            prices[(int)Room.Studio] = (_month == "September" ? nights - 1 : nights) * RoomPrice_Month[(int)Room.Studio, (int)month];
            prices[(int)Room.Double] = nights * RoomPrice_Month[(int)Room.Double, (int)month] * (month == (Months)1 ? discount[(int)month] : 1);
            prices[(int)Room.Suite] = nights * RoomPrice_Month[(int)Room.Suite, (int)month] * (month == (Months)2 ? discount[(int)month] : 1);
        }
        else
        {
            prices[(int)Room.Studio] = ((_month == "September" || _month == "October")&&nights>7 ? nights - 1 : nights) * RoomPrice_Month[(int)Room.Studio, (int)month];
            prices[(int)Room.Double] = nights * RoomPrice_Month[(int)Room.Double, (int)month];
            prices[(int)Room.Suite] = nights * RoomPrice_Month[(int)Room.Suite, (int)month];
        }

        WriteLine($@"Studio: {prices[(int)Room.Studio]:f2} lv.
Double: {prices[(int)Room.Double]:f2} lv.
Suite: {prices[(int)Room.Suite]:f2} lv.");
    }
}
