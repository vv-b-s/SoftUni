using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Animals.Abstracts;
using Wild_Farm.Foods;

namespace Wild_Farm.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, string weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed) { }

        protected override double WeightGain => 1;

        public override string GenerateHungrySound() => "ROAR!!!";

        protected override bool AnimalCanEat(Food food) => food is Meat;
    }
}
