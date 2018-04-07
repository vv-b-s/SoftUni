using System;
using System.Collections.Generic;
using System.Text;

namespace Database.App.Contracts
{
    public interface IPerson
    {
        long Id { get; }
        string Name { get; }
    }
}
