using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizza_Calories.Ingredients
{
    public class Dough : Ingredient
    {
        private Dictionary<string, double> doughTypes = new Dictionary<string, double>
        {
            { "Wholegrain",1 },
            { "White", 1.5 }
        };

        private Dictionary<string, double> additions = new Dictionary<string, double>
        {
            { "Crispy",  0.9},
            { "Chewy" , 1.1},
            { "Homemade" , 1.0}
        };

        private string doughType;
        private string addition;
        private double weight;

        public Dough(string doughType, string addition, double weight)
        {
            DoughType = doughType;
            Addition = addition;
            Weight = weight;
        }

        public string DoughType
        {
            get => doughType;
            private set => doughType = ValidateDough(value, doughTypes);
        }

        public string Addition
        {
            get => addition;
            private set => addition = ValidateDough(value, additions);
        }

        public override double Weight
        {
            get => weight;
            protected set
            {
                if (value < 1 || value > 200)
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                weight = value;
            }
        }

        public override double GetCalories()
        {
            var doughCalories = doughTypes[doughType];
            var additionCalories = additions[addition];

            return base.GetCalories() * doughCalories * additionCalories;
        }

        private string ValidateDough(string doughType, Dictionary<string, double> collection)
        {
            var foundKey = "";

            //Check if any key is eqal to the give type and assign that value to the found key
            if (collection.Keys.Any(k => Validation(k, doughType, out foundKey)))
                return foundKey;
            else throw new ArgumentException("Invalid type of dough.");
        }
    }

}
