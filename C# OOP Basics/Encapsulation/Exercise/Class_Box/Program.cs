using System;
using System.Reflection;

namespace Class_Box
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var box = new Box(length: ReadDouble(), width: ReadDouble(), height: ReadDouble());
                Console.WriteLine(box);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }
        }

        private static double ReadDouble() => double.Parse(Console.ReadLine());
    }
}
