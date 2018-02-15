using System;
using static System.Console;

namespace Define_a_class_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfMembersToAdd = int.Parse(ReadLine());

            var family = new Family();

            while(numberOfMembersToAdd-->0)
            {
                var data = ReadLine().Split();
                var name = data[0];
                var age = int.Parse(data[1]);

                family.AddMember(new Person(name, age));
            }


            WriteLine(string.Join("\n", family.GetSortedMembersWithAgeAbove(30)));
        }
    }
}
