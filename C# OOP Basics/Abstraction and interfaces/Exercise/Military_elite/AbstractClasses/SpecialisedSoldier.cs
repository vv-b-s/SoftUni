using Military_elite.ImplementableSoldiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_elite.AbstractClasses
{
    public abstract class SpecialisedSoldier : Private
    {
        private string corps;

        public SpecialisedSoldier(string id, string firstName, string lastName, double salary, string corps) : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public string Corps
        {
            get=> corps;
            set
            {
                if (value == "Airforces" || value == "Marines")
                    corps = value;

                else throw new ArgumentException("Corps not valid");
            }
        }

        public override string ToString() => $"{base.ToString()}\nCorps: {corps}";
    }
}
