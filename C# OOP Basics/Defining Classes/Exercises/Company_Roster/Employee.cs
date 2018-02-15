using System;
using System.Collections.Generic;
using System.Text;

namespace Company_Roster
{
    public class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public Employee(string name, decimal saley, string position, string department)
        {
            Name = name;
            Salary = saley;
            Position = position;
            Department = department;

            Email = "n/a";
            Age = -1;
        }

        public Employee(string name, decimal saley, string position, string department, string email) : this(name, saley, position, department)
        {
            Email = email;
        }

        public Employee(string name, decimal saley, string position, string department, int age = -1) : this(name, saley, position, department)
        {
            Age = age;
        }

        public Employee(string name, decimal saley, string position, string department, string email, int age) : this(name, saley, position, department, age) { Email = email; }

        public override string ToString() => $"{Name} {Salary:f2} {Email} {Age}";
    }
}
