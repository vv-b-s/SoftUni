using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Frog : Animal
    {
        public Frog(string name, int age, Gender gender) : base(name, age, gender) { }

        public override string ProduceSound() => "Ribbit";
    }
}
