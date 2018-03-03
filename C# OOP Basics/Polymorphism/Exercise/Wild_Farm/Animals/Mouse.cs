using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Animals.Abstracts;
using Wild_Farm.Foods;

namespace Wild_Farm.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, string weight, string livingRegion) : base(name, weight, livingRegion) { }

        protected override double WeightGain => 0.10;

        public override string GenerateHungrySound() => "Squeak";

        protected override bool AnimalCanEat(Food food) => food is Fruit || food is Vegetable;
    }
}
