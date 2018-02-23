using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Spree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> productsBag;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;

            productsBag = new List<Product>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");

                else name = value;
            }
        }

        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");

                else money = value;
            }
        }

        /// <summary>
        /// Try to add a product to the product bag and return the result of the trial
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool BuyProduct(Product product)
        {
            if (product.Cost > Money)
                return false;

            productsBag.Add(product);
            Money -= product.Cost;
            return true;
        }

        public override string ToString()
        {
            if (productsBag.Count == 0)
                return $"{Name} - Nothing bought";

            else return $"{Name} - {string.Join(", ", productsBag)}";
        }
    }
}
