using System;
using System.Collections.Generic;
using System.Text;

namespace Food_Shortage
{
    public abstract class Human
    {
        public Human(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
