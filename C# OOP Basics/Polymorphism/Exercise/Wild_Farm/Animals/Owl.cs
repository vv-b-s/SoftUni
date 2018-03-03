using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Animals.Abstracts;
using Wild_Farm.Foods;

namespace Wild_Farm.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, string weight, string wingSize) : base(name, weight, wingSize) { }

        protected override double WeightGain => 0.25;

        public override string GenerateHungrySound() => "Hoot Hoot";

        protected override bool AnimalCanEat(Food food) => food is Meat;
    }
}
