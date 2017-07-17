using static System.Console;

class Program
{
    static void Main()
    {
        int num = int.Parse(ReadLine())*2;
        int sum = 0;
        for(int i=1;i<num;i+=2)
        {
            WriteLine(i);
            sum += i;
        }
        WriteLine($"Sum: {sum}");
    }
}
