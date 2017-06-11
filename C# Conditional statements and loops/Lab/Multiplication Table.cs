using static System.Console;

class Program
{
    static void Main()
    {
        int num = int.Parse(ReadLine());
        for (int i = 1; i <= 10; i++)
            WriteLine($"{num} X {i} = {num * i}");
    }
}
