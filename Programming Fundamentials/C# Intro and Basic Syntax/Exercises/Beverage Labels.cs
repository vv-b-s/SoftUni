using static System.Console;

class Program
{
    static void Main()
    {
        string productName = ReadLine();
        int amount = int.Parse(ReadLine());
        double calories = (amount / 100d) * int.Parse(ReadLine());
        double sugars = (amount / 100d) * int.Parse(ReadLine());

        WriteLine($"{amount}ml {productName}:\n{calories}kcal, {sugars}g sugars");
    }
}
