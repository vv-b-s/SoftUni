using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Animals.Abstracts;
using Wild_Farm.Foods;

namespace Wild_Farm.Animals
{
    class Hen : Bird
    {
        public Hen(string name, string weight, string wingSize) : base(name, weight, wingSize) { }

        protected override double WeightGain => 0.35;

        public override string GenerateHungrySound() => "Cluck";

        protected override bool AnimalCanEat(Food food) => true;
    }
}
