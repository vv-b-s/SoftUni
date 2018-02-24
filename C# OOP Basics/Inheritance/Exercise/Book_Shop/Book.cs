using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Shop
{
    public class Book
    {
        string title;
        string author;
        decimal price;

        public Book(string author, string title, decimal price )
        {
            Author = author;
            Title = title;
            Price = price;
        }

        public string Title
        {
            get => title;
            set
            {
                if (value.Length < 3)
                    throw new ArgumentException("Title not valid!");
                else title = value;
            }
        }

        public string Author
        {
            get => author;
            set
            {
                var authorNames = value.Split();
                if (authorNames.Length > 1 && char.IsDigit(authorNames[1][0]))
                    throw new ArgumentException("Author not valid!");
                else author = value;
            }
        }

        public virtual decimal Price
        {
            get => price;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Price not valid!");
                else price = value;
            }
        }

        public override string ToString() =>
            $"Type: {GetType().Name}\n" +
            $"Title: {Title}\n" +
            $"Author: {Author}\n" +
            $"Price: {Price:F2}";
    }
}
