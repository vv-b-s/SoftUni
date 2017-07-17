using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using static System.Console;

class Book
{
    public string Title             { set; get; }
    public string Publisher         { set; get; }
    public DateTime ReleaseDate     { set; get; }
    string ISBN                     { set; get; }
    public decimal Price            { set; get; }

    public Book(string title, string publisher, string releaseDate, string ISBN, string price)
    {
        Title = title;
        Publisher = publisher;
        ReleaseDate = DateTime.ParseExact(releaseDate, "d.MM.yyyy", CultureInfo.InvariantCulture);
        this.ISBN = ISBN;
        Price = decimal.Parse(price);
    }
}

class Library
{
    Dictionary<string, List<Book>> authorBooks        = new Dictionary<string, List<Book>>();

    public void AddAuthor(string name, Book book)     => authorBooks[name] = new List<Book> { book };

    public void AddBook(string authorName, Book book) => authorBooks[authorName].Add(book);

    public bool HasAuthor(string name)                => authorBooks.ContainsKey(name);

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

    public string ListBooksAfterDate(string day, string month, string year)
    {
        string formatedDate = $"{day}.{month}.{year}";
        var date = DateTime.ParseExact(formatedDate, "d.MM.yyyy", CultureInfo.InvariantCulture);

        var allBooksList = authorBooks.Values.ToList();
        var booksAfterCertainDate = new List<Book>();

        foreach(var bookList in allBooksList)
            foreach(var book in bookList)
                if (book.ReleaseDate.Date > date.Date)
                    booksAfterCertainDate.Add(book);

        booksAfterCertainDate = booksAfterCertainDate.OrderBy(b=>b.ReleaseDate.Date).ThenBy(b=>b.Title).ToList();

        var bookData = new StringBuilder();
        foreach (var book in booksAfterCertainDate)
            bookData.AppendLine(book.Title + " -> " + book.ReleaseDate.Date.ToString("d.MM.yyyy"));
        return bookData.ToString();
    }
}

class Program
{
    static void Main()
    {
        var lib = new Library();

        for (int i = int.Parse(ReadLine()); i > 0; i--)
        {
            var input = ReadLine().Split().ToArray();
            string bookName    = input[0];
            string bookAuthor  = input[1];
            string publisher   = input[2];
            string releaseDate = input[3];
            string ISBN        = input[4];
            string price       = input[5];

            if (lib.HasAuthor(bookAuthor))
                lib.AddBook(bookAuthor, new Book(bookName, publisher, releaseDate, ISBN, price));
            else
                lib.AddAuthor(bookAuthor, new Book(bookName, publisher, releaseDate, ISBN, price));
        }
        string[] afterDate = ReadLine().Split('.');

        Write(lib.ListBooksAfterDate(afterDate[0],afterDate[1],afterDate[2]));
    }
}