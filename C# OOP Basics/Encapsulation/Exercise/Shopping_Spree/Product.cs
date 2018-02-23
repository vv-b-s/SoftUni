﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Spree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
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

        public decimal Cost
        {
            get => cost;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");

                else cost = value;
            }
        }

        public override string ToString() => Name;
    }
}
