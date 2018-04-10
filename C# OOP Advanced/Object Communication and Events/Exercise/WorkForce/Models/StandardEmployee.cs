using System;
using System.Collections.Generic;
using System.Text;

namespace WorkForce.Models
{
    public class StandardEmployee : Employee
    {
        public const int DefaultWorkingHours = 40;

        public StandardEmployee(string name) : base(name, 40) { }
    }
}
