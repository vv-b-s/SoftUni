using Military_elite.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_elite.ImplementableSoldiers
{
    public class Private:Soldier
    {
        private double salary;

        public Private(string id, string firstName,string lastName, double salary):base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public virtual double Salary
        {
            get => salary;
            set
            {
                if (salary >= 0)
                    salary = value;

                else throw new ArgumentException("Invalid salery");
            }
        }

        public override string ToString() => base.ToString() + $" Salary: {Salary:F2}";
    }
}
