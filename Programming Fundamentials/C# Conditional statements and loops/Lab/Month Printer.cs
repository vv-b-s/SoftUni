using static System.Console;

class Program
{
    enum months { January=1, February, March, April, May, June, July, August, September, October, November, December}
    static void Main()
    {
        var monthNum = int.Parse(ReadLine());
        months month = (months)monthNum;
        WriteLine(monthNum >= 1 && monthNum <= 12 ? month.ToString() : "Error!");
    }
}
