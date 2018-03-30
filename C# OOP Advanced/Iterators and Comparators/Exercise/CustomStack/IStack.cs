using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public interface IStack<T>:IEnumerable<T>
    {
        void Push(T item);
        T Pop();
    }
}
