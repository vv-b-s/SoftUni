using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Animals.Abstracts;
using Wild_Farm.Foods;

namespace Wild_Farm.Animals
{
    class Dog : Mammal
    {
        public Dog(string name, string weight, string livingRegion) : base(name, weight, livingRegion) { }

        protected override double WeightGain => 0.4;

        public override string GenerateHungrySound() => "Woof!";

        protected override bool AnimalCanEat(Food food) => food is Meat;
    }
}
