using System;
using System.Collections.Generic;
using System.Text;

public interface ILibrary<TBook> : IEnumerable<TBook> where TBook:IBook
{
    IReadOnlyList<TBook> Books { get; }
}