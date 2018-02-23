using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Calories.Ingredients
{
    public abstract class Ingredient
    {
        private const double DEFAULT_CALORIES_PER_GRAM = 2;
        public abstract double Weight { get; protected set; }

        /// <summary>
        /// Calculate the calories of the ingredient. By default they are 2
        /// </summary>
        /// <returns></returns>
        public virtual double GetCalories() => Weight * DEFAULT_CALORIES_PER_GRAM;

        /// <summary>
        /// Use this method to ignore casing when checking if an entered ingredient is existent
        /// Use the out parameter to get the recorded name of the key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="comparingKey"></param>
        /// <param name="selectedKey"></param>
        /// <returns></returns>
        protected static bool Validation(string key, string comparingKey, out string selectedKey)
        {
            selectedKey = "";

            if (key.Equals(comparingKey, StringComparison.InvariantCultureIgnoreCase))
            {
                selectedKey = key;
                return true;
            }

            else return false;
        }
    }
}
