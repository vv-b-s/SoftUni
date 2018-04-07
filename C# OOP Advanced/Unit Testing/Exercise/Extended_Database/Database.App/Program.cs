using System;

namespace Database.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] people =
            {
                new Person("Ani"),
                new Person("Petya"),
                new Person("Gosho")
            };

            var db = new Database(people);


            Console.WriteLine(db.NumberOfStoredItems);


            var person = db.Remove();
            Console.WriteLine(person.Name);
            Console.WriteLine(db.NumberOfStoredItems);
        }
    }
}
