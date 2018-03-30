using System;
using System.Collections.Generic;
using System.Text;

namespace Equality_Logic
{
    //Following this logic: https://blogs.msdn.microsoft.com/ericlippert/2011/02/28/guidelines-and-rules-for-gethashcode/
    public class Person:IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int CompareTo(Person other)
        {
            var result = this.Name.CompareTo(other.Name);

            return result == 0 ? this.Age.CompareTo(other.Age) : result;
        }

        public override bool Equals(object obj)
        {
            var otherPerson = obj as Person;

            return otherPerson.Name == this.Name && otherPerson.Age == this.Age;
        }

        public override int GetHashCode()
        {
            var hashCode = 0;
            foreach (var c in this.Name)
                hashCode += c * this.Age;

            return hashCode;
        }
    }
}
