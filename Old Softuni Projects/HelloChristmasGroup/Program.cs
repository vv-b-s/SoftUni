using static System.Console;

namespace HelloChristmasGroup
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(ReadLine());

            for (int i = 0; i < n; i++)
            {
                if (i == 0 || i == n - 1)
                {
                    for (int j = 0; j < n; j++)
                        Write('*');
                    WriteLine();
                }
                else
                {
                    Write('*');
                    for (int k = 0; k < n - 2; k++)
                        Write(' ');
                    Write('*');
                    WriteLine();
                }
            }
        }
    }
}
