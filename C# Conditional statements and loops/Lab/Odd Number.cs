using static System.Console;

class Program
{
    static void Main()
    {
        int number;
        do
        {
            number = int.Parse(ReadLine());
            if (number % 2 != 0)
                WriteLine($"The number is: {System.Math.Abs(number)}");
            else
                WriteLine("Please write an odd number.");
        }
        while (number % 2 == 0);
    }
}
