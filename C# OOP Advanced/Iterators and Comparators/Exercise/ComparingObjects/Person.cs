using System;
using System.Collections.Generic;
using System.Text;

namespace ComparingObjects
{
    public class Person : IPerson
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Town { get; private set; }

        public int CompareTo(IPerson other)
        {
            var result = this.Name.CompareTo(other.Name);

            if (result == 0)
                result = this.Age.CompareTo(other.Age);

            if (result == 0)
                result = this.Town.CompareTo(other.Town);

            return result;
        }

        public class NameComparator : IComparer<Person>
        {
            public int Compare(Person p1, Person p2)
            {
                var result = p1.Name.Length.CompareTo(p2.Name.Length);

                if (result == 0)
                    result = p1.Name.ToLower()[0].CompareTo(p2.Name.ToLower()[0]);

                return result;
            }
        }

        public class AgeComparator : IComparer<Person>
        {
            public int Compare(Person p1, Person p2)
            {
                return p1.Age.CompareTo(p2.Age);
            }
        }
    }
}
