using static System.Console;

class Program
{
    static void Main()
    {
        int[,] price =
        {
            { 12,18,12 },
            { 15,20,15 },
            {5,12,10 }
        };

        string day = ReadLine().ToLower();
        var age = int.Parse(ReadLine());

        switch(day)
        {
            case "weekday":
                if (age >= 0 && age <= 18)
                    WriteLine(price[0, 0]+"$");
                else if (age > 18 && age <= 64)
                    WriteLine(price[0, 1] + "$");
                else if (age > 64 && age <= 122)
                    WriteLine(price[0, 2] + "$");
                else
                    WriteLine("Error!");
                break;
            case "weekend":
                if (age >= 0 && age <= 18)
                    WriteLine(price[1, 0] + "$");
                else if (age > 18 && age <= 64)
                    WriteLine(price[1, 1] + "$");
                else if (age > 64 && age <= 122)
                    WriteLine(price[1, 2] + "$");
                else
                    WriteLine("Error!");
                break;
            case "holiday":
                if (age >= 0 && age <= 18)
                    WriteLine(price[2, 0] + "$");
                else if (age > 18 && age <= 64)
                    WriteLine(price[2, 1] + "$");
                else if (age > 64 && age <= 122)
                    WriteLine(price[2, 2] + "$");
                else
                    WriteLine("Error!");
                break;
            default:
                WriteLine("Error!");
                break;
        }
    }
}
