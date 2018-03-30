using System;
using System.Collections.Generic;
using System.Text;

public interface IBook:IComparable<Book>
{
    string Title { get; }
    int Year { get; }

    IReadOnlyList<string> Authors { get; }
}