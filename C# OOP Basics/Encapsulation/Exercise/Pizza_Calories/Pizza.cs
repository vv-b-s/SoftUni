using Pizza_Calories.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizza_Calories
{
    class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");

                else name = value;
            }
        }

        public int NumberOfToppings => toppings.Count;

        public Dough Dough
        {
            get => dough;
            set => dough = value;
        }

        public double TotalCalories
        {
            get
            {
                var doughCalories = dough.GetCalories();
                var toppingsCalories = toppings.Sum(t => t.GetCalories());

                return doughCalories + toppingsCalories;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (NumberOfToppings < 10)
                toppings.Add(topping);

            else throw new ArgumentException("Number of toppings should be in range [0..10].");
        }

        public override string ToString() => $"{Name} - {TotalCalories:F2} Calories.";
    }
}
