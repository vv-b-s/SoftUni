using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public interface IIterator<TItem>
    {
        bool Move();
        bool HasNext { get; }
        TItem Print();
    }
}
