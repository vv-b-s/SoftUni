using System;
using System.Collections.Generic;
using System.Text;

namespace Google.PersonData
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Pokemon(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString() => $"{Name} {Type}";
    }
}
