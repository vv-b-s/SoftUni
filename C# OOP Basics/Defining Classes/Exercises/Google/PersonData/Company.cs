using System;
using System.Collections.Generic;
using System.Text;

namespace Google.PersonData
{
    public class Company
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salery { get; set; }

        public Company() { }

        public Company(string name, string department, decimal salery)
        {
            Name = name;
            Department = department;
            Salery = salery;
        }

        public override string ToString() => $"{Name} {Department} {Salery:F2}";
    }
}
