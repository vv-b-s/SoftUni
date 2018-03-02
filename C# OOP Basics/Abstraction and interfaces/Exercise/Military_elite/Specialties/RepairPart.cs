using System;
using System.Collections.Generic;
using System.Text;

namespace Military_elite.Specialties
{
    public class RepairPart
    {
        public RepairPart(string name, int hours)
        {
            Name = name;

            if (hours >= 0)
                Hours = hours;
            else throw new ArgumentException("Invalid hours");
        }

        public int Hours { get; set; }
        public string Name { get; set; }

        public override string ToString() => $"  Part Name: {Name} Hours Worked: {Hours}";
    }
}
