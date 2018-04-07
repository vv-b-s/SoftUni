using System;

namespace Database.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Console.WriteLine(string.Join(" ", db.Fetch()));

            db.Remove();

            Console.WriteLine(string.Join(" ", db.Fetch()));

            db.Add(5);

            Console.WriteLine(string.Join(" ", db.Fetch()));
        }
    }
}
