using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, Gender gender) : base(name, age, gender) { }

        public override Gender AnimalGender
        {
            get => base.AnimalGender;
            set => base.AnimalGender = Gender.Female;
        }

        public override string ProduceSound() => "Meow";
    }
}
