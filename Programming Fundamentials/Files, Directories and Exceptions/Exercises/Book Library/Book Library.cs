using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using static System.Console;

class Book
{

    public string Title { set; get; }
    public string Publisher { set; get; }
    public string ReleaseDate { set; get; }
    string ISBN { set; get; }
    public decimal Price { set; get; }

    public Book(string title, string publisher, string releaseDate, string ISBN, string price)
    {
        Title = title;
        Publisher = publisher;
        ReleaseDate = releaseDate;
        this.ISBN = ISBN;
        Price = decimal.Parse(price);
    }
}

class Library
{
    Dictionary<string, List<Book>> authorBooks = new Dictionary<string, List<Book>>();

    public void AddAuthor(string name, Book book) => authorBooks[name] = new List<Book> { book };

    public void AddBook(string authorName, Book book) => authorBooks[authorName].Add(book);

    public bool HasAuthor(string name) => authorBooks.ContainsKey(name);

    public string ListAuthorSalery()
    {
        var authorSalery = authorBooks.ToDictionary(k => k.Key, v => v.Value.Sum(a => a.Price));
        authorSalery = authorSalery.OrderByDescending(p => p.Value).ThenBy(a => a.Key)
            .ToDictionary(k => k.Key, v => v.Value);

        var sB = new StringBuilder();
        foreach (var author in authorSalery)
            sB.AppendLine(author.Key + " -> " + author.Value.ToString("f2"));

        return sB.ToString();
    }
}

class Program
{
    static void Main()
    {
        var inText = File.ReadAllLines(@"X:\Development\SoftUni\Files, Directories and Exceptions\Exercises\Book Library\input.txt");
        var lib = new Library();

        for (int i = 1; i < int.Parse(inText[0])+1; i++)
        {
            var input = inText[i].Split().ToArray();
            string bookName = input[0];
            string bookAuthor = input[1];
            string publisher = input[2];
            string releaseDate = input[3];
            string ISBN = input[4];
            string price = input[5];

            if (lib.HasAuthor(bookAuthor))
                lib.AddBook(bookAuthor, new Book(bookName, publisher, releaseDate, ISBN, price));
            else
                lib.AddAuthor(bookAuthor, new Book(bookName, publisher, releaseDate, ISBN, price));
        }

        File.WriteAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\Exercises\Book Library\output.txt",lib.ListAuthorSalery());
    }
}