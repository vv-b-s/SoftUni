using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Animals.Abstracts
{
    public abstract class Bird : Animal
    {
        private double wingSize;

        public Bird(string name, string weight, string wingSize) : base(name, weight)
        {
            this.WingSize = double.Parse(wingSize);
        }

        public double WingSize
        {
            get { return wingSize; }
            set { wingSize = value; }
        }

        public override string ToString() => string.Format(base.ToString(), $"{this.WingSize}, {this.Weight}");
    }
}
