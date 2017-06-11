using static System.Console;

class Program
{
    static void Main()
    {
        var grade = double.Parse(ReadLine());
        Write(grade >= 3 ? "Passed!\n" : "");
    }
}
