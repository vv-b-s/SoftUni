using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Animals.Abstracts;
using Wild_Farm.Foods;

namespace Wild_Farm.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, string weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed) { }

        protected override double WeightGain => 0.3;

        public override string GenerateHungrySound() => "Meow";

        protected override bool AnimalCanEat(Food food) => food is Vegetable || food is Meat;
    }
}
