using Pet_Clinics.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pet_Clinics.Entities
{
    public class Pet : IPet
    {
        public Pet(string name, int age, string kind)
        {
            this.Name = name;
            this.Age = age;
            this.Kind = kind;
        }

        public string Name { get; }

        public int Age { get; }

        public string Kind { get; }

        public override string ToString()
        {
            var representation = $"{this.Name} {this.Age} {this.Kind}";
            return representation;
        }
    }
}
