using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Library:ILibrary<Book>
{
    private List<Book> books;

    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);
    }

    public IReadOnlyList<Book> Books
    {
        get
        {
            this.books.Sort();
            return this.books;
        }
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.Books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> books;
        private int index = -1;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.books = books.ToList();
        }

        public Book Current => this.books[index];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
            Reset();
        }

        public bool MoveNext()
        {
            this.index++;
            return index < this.books.Count;
        }

        public void Reset()
        {
            this.index = -1;
        }
    }
}
