using static System.Console;

class Program
{
    static void Main()
    {
        int num = int.Parse(ReadLine());
        int endNum = int.Parse(ReadLine());
        if(endNum<=10)
            for (int i = endNum; i <= 10; i++)
                WriteLine($"{num} X {i} = {num * i}");
        else
            WriteLine($"{num} X {endNum} = {num * endNum}");
    }
}
