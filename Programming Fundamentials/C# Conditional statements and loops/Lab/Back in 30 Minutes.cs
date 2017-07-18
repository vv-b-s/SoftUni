using static System.Console;

class Program
{
    static void Main()
    {
        var hours = int.Parse(ReadLine());
        var minutes = double.Parse(ReadLine());
        minutes += hours * 60 + 30;
        hours = ((int)minutes / 60)%24;
        minutes -= hours * 60;
        minutes %= 60;
        WriteLine($"{hours}:{(int)minutes:D2}");
    }
}
