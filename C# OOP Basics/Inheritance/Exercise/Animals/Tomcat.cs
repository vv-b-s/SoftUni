using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, Gender gender) : base(name, age, gender) { }

        public override Gender AnimalGender
        {
            get => base.AnimalGender;
            set => base.AnimalGender = Gender.Male;
        }

        public override string ProduceSound() => "MEOW";
    }
}
