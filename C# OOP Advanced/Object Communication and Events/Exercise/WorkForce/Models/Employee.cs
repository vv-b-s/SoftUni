using System;
using System.Collections.Generic;
using System.Text;
using WorkForce.Contracts;

namespace WorkForce.Models
{
    public abstract class Employee : IEmployee
    {
        protected Employee(string name, int workingHoursPerWeek)
        {
            this.Name = name;
            this.WorkingHoursPerWeek = workingHoursPerWeek;
        }

        public string Name { get; }

        public int WorkingHoursPerWeek { get; }
    }
}
