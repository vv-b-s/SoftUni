using System;
using System.Collections.Generic;
using System.Text;

namespace Pet_Clinics.Contracts
{
    public interface IPet
    {
        string Name { get; }
        int Age { get; }
        string Kind { get; }
    }
}
