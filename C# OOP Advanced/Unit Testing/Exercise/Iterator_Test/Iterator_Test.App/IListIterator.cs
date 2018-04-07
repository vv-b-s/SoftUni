using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator_Test.App
{
    public interface IListIterator<T>
    {
        bool Move();
        bool HasNext();
        T Print();
    }
}
