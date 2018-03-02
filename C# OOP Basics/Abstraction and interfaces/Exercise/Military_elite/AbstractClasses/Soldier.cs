using System;
using System.Collections.Generic;
using System.Text;

namespace Military_elite.AbstractClasses
{
    public abstract class Soldier
    {
        private string id;
        private string firstName;
        private string lastName;

        public Soldier(string id, string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public virtual string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        public virtual string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public virtual string Id
        {
            get => id;
            set => id = value;
        }

        public virtual string FullName => $"{FirstName} {LastName}";

        public override string ToString() => $"Name: {FullName} Id: {id}";
    }
}
