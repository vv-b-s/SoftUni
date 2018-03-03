using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Foods;

namespace Wild_Farm.Animals.Abstracts
{
    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        public Animal(string name, string weight)
        {
            this.Name = name;
            this.Weight = double.Parse(weight);
        }

        public int FoodEaten
        {
            get { return foodEaten; }
            set { foodEaten = value; }
        }
        
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        protected abstract double WeightGain { get; }

        public void TryToFeed(Food food)
        {
            if (AnimalCanEat(food))
            {
                this.Weight += WeightGain * food.Quantity;
                this.FoodEaten+=food.Quantity;
            }

            else throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        public abstract string GenerateHungrySound();

        protected abstract bool AnimalCanEat(Food food);

        /// <summary>
        /// Provides a string with a placeholder to fill in the gap
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var pleceholder = "{0}";

            return $"{this.GetType().Name} [{this.name}, {pleceholder}, {foodEaten}]";
        }
    }
}
