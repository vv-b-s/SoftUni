using static System.Console;

class Program
{
    static void Main()
    {
        var grade = double.Parse(ReadLine());
        WriteLine(grade >2.99 ? "Passed!" : "Failed!");
    }
}
