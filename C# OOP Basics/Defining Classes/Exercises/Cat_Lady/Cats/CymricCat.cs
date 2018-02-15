using System;
using System.Collections.Generic;
using System.Text;

namespace Cat_Lady.Cats
{
    public class CymricCat : Cat
    {
        public override string Name { get; set; }
        public double FurLength { get; set; }

        public CymricCat(string name, double furLength)
        {
            Name = name;
            FurLength = furLength;
        }

        public override string ToString() => $"Cymric {Name} {FurLength:F2}";
    }
}
