using System;
using System.Collections.Generic;

namespace Equality_Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfPeople = int.Parse(Console.ReadLine());

            var peopleHashSet = new HashSet<Person>();
            var peopleSortedSet = new SortedSet<Person>();

            while(numberOfPeople-->0)
            {
                var data = Console.ReadLine().Split();
                var person = new Person(data[0], int.Parse(data[1]));

                peopleHashSet.Add(person);
                peopleSortedSet.Add(person);
            }

            Console.WriteLine(peopleHashSet.Count);
            Console.WriteLine(peopleSortedSet.Count);
        }
    }
}
