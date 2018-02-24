using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Shop
{
    public class GoldenEditionBook:Book
    {
        public GoldenEditionBook(string author, string title, decimal price) : base(author, title, price) { }

        public override decimal Price
        {
            get => base.Price;
            set => base.Price = value * 1.3m;
        }
    }
}
