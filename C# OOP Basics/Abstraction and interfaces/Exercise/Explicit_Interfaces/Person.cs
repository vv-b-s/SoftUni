using System;
using System.Collections.Generic;
using System.Text;

namespace Explicit_Interfaces
{
    public class Person : IResident, IPerson
    {
        public Person(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        string IResident.GetName() => $"Mr/Ms/Mrs {((IPerson)this).GetName()}";

        string IPerson.GetName() => Name;
    }
}
