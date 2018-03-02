using System;

namespace Explicit_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";

            while((input = Console.ReadLine())!="End")
            {
                var data = input.Split();

                var person = new Person(name: data[0], country: data[1], age: int.Parse(data[2]));

                var iPerson = person as IPerson;
                var iResident = person as IResident;

                Console.WriteLine(iPerson.GetName());
                Console.WriteLine(iResident.GetName());
            }
        }
    }
}
