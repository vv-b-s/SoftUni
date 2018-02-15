using System;
using System.Collections.Generic;
using System.Text;

namespace Cat_Lady.Cats
{
    public class SiameseCat : Cat
    {
        public override string Name { get; set; }
        public long EarSize { get; set; }

        public SiameseCat(string name, long earSize)
        {
            Name = name;
            EarSize = earSize;
        }

        public override string ToString() => $"Siamese {Name} {EarSize}";
    }
}
