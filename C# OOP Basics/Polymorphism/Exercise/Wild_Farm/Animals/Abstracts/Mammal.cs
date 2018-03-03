using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Animals.Abstracts
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;

        public Mammal(string name, string weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get { return livingRegion; }
            set { livingRegion = value; }
        }

        public override string ToString() => string.Format(base.ToString(), $"{this.Weight}, {this.LivingRegion}");
    }
}
