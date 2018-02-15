using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon_Trainer
{
    class Pokemon
    {
        public string Name { get; set; }
        public string Element { get; set; }
        public double Health { get; set; }

        public Pokemon(string name, string element, double helath)
        {
            Name = name;
            Element = element;
            Health = helath;
        }
    }
}
