using static System.Console;

class Program
{
    static void Main()
    {
        string number = ReadLine();
        double num;
        WriteLine(double.TryParse(number, out num)? "It is a number." : "Invalid input!");
    }
}
