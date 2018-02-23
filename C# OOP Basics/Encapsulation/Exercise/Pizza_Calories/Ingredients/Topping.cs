using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizza_Calories.Ingredients
{
    class Topping : Ingredient
    {
        private double weight;
        private string toppingType;

        private Dictionary<string, double> toppingTypes = new Dictionary<string, double>
        {
            { "Meat", 1.2 },
            { "Veggies", 0.8 },
            { "Cheese", 1.1 },
            { "Sauce", 0.9 }
        };

        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        public string ToppingType
        {
            get => toppingType;
            private set
            {
                var correctKey = "";
                if (toppingTypes.Keys.Any(k => Validation(k, value, out correctKey)))
                    toppingType = correctKey;
                else throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
        }

        public override double Weight
        {
            get => weight;
            protected set
            {
                if (value >= 1 && value <= 50)
                    weight = value;
                else throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
            }
        }

        public override double GetCalories() => base.GetCalories() * toppingTypes[toppingType];
    }
}
