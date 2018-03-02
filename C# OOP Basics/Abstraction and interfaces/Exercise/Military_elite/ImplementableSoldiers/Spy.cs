using Military_elite.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_elite.ImplementableSoldiers
{
    public class Spy : Soldier
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            if (codeNumber >= 0)
                CodeNumber = codeNumber;
            else throw new ArgumentException("Invalid code number");
        }

        public int CodeNumber { get; set; }

        public override string ToString() => $"{base.ToString()}\nCode Number: {CodeNumber}";
    }
}
