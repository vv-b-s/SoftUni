using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, Gender gender) : base(name, age, gender) { }

        public override string ProduceSound() => "Meow meow";
    }
}
