using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Book : IBook
{
    private string title;
    private int year;
    private List<string> authors;

    public Book(string title, int year, params string[] authors)
    {
        this.title = title;
        this.year = year;
        this.authors = new List<string>(authors);
    }

    public string Title => this.title;

    public int Year => this.year;

    public IReadOnlyList<string> Authors => this.authors;

    public int CompareTo(Book other)
    {
        var yearComparationResult = this.year.CompareTo(other.year);

        if (yearComparationResult == 0)
            return this.title.CompareTo(other.title);

        else return yearComparationResult;
    }

    public override string ToString()
    {
        var text = $"{this.title} - {this.year}";
        return text;
    }
}