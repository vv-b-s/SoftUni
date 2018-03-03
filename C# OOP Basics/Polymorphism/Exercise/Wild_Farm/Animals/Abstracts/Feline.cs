using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Animals.Abstracts
{
    public abstract class Feline : Mammal
    {
        private string breed;

        public Feline(string name, string weight, string livingRegion, string breed) : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }

        public override string ToString()
        {
            var pleceholder = "{0}";

            var output = string.Format($"{this.GetType().Name} [{this.Name}, {pleceholder}, {this.FoodEaten}]",
                $"{this.Breed}, {this.Weight}, {this.LivingRegion}");

            return output;
        }
    }
}
