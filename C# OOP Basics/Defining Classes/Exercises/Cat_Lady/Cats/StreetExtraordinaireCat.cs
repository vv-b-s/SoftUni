using System;
using System.Collections.Generic;
using System.Text;

namespace Cat_Lady.Cats
{
    public class StreetExtraordinaireCat:Cat
    {
        public override string Name { get; set; }
        public long DecibelsOfMeowing { get; set; }

        public StreetExtraordinaireCat(string name, long decibelsOfMeowing)
        {
            Name = name;
            DecibelsOfMeowing = decibelsOfMeowing;
        }

        public override string ToString() => $"StreetExtraordinaire {Name} {DecibelsOfMeowing}";
    }
}
