using System;

namespace Rhombus_Of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            var rhombus = new Rhombus(int.Parse(Console.ReadLine()));
            Console.Write(rhombus.Shape);
        }
    }
}
