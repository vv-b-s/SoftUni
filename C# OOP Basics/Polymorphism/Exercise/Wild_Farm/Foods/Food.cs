﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Foods
{
    public abstract class Food
    {
        private int quantity;

        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

    }
}
