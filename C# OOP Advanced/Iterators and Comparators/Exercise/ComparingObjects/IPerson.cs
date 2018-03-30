using System;
using System.Collections.Generic;
using System.Text;

namespace ComparingObjects
{
    public interface IPerson: IComparable<IPerson>
    {
        string Name { get; }
        int Age { get; }
        string Town { get; }
    }
}
