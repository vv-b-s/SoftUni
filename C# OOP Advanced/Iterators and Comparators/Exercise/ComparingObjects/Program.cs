using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfPeople = int.Parse(Console.ReadLine());

            var ageSorted = new SortedSet<Person>(new Person.AgeComparator());
            var nameSorted = new SortedSet<Person>(new Person.NameComparator());

            while (numberOfPeople-- > 0)
            {
                var personData = Console.ReadLine().Split();
                var person = new Person(personData[0], int.Parse(personData[1]), null);

                ageSorted.Add(person);
                nameSorted.Add(person);
            }

            Console.WriteLine(string.Join(Environment.NewLine, nameSorted.Select(p => $"{p.Name} {p.Age}")));
            Console.WriteLine(string.Join(Environment.NewLine, ageSorted.Select(p => $"{p.Name} {p.Age}")));
        }
    }
}
