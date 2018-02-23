namespace AnimalFarm.Models
{
    using System;

    public class Chicken
    {
        public const int MIN_AGE = 0;
        public const int MAX_AGE = 15;

        private string name;
        private int age;

        internal Chicken(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get => name;

            internal set
            {
                if (value is null || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");
                name = value;
            }
        }

        public int Age
        {
            get => age;

            protected set
            {
                if (value < 0 || value > 15)
                    throw new ArgumentException("Age should be between 0 and 15.");
                age = value;
            }
        }

        /// <summary>
        /// Public accessor to getting the daily product
        /// </summary>
        /// <returns></returns>
        public double GetProductPerDay() => CalculateProductPerDay();

        /// <summary>
        /// Calculate the daily product
        /// </summary>
        /// <returns></returns>
        private double CalculateProductPerDay()
        {
            if (age >= 0 && age <= 3)
                return 1.5;
            else if (age > 3 && age <= 7)
                return 2;
            else if (age > 7 && age <= 11)
                return 1;
            else return 0.75;
        }
    }
}
