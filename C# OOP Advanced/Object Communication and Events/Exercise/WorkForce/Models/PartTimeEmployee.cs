using System;
using System.Collections.Generic;
using System.Text;

namespace WorkForce.Models
{
    public class PartTimeEmployee : Employee
    {
        public const int DefaultWorkHours = 20;

        public PartTimeEmployee(string name) : base(name, DefaultWorkHours) { }
    }
}
