using System;
using System.Collections.Generic;
using System.Text;

namespace Cat_Lady.Cats
{
    public abstract class Cat
    {
        public abstract string Name { get; set; }

        public abstract override string ToString();
    }
}
