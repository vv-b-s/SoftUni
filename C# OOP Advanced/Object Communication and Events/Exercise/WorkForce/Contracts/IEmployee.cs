using System;
using System.Collections.Generic;
using System.Text;

namespace WorkForce.Contracts
{
    public interface IEmployee
    {
        string Name { get; }
        int WorkingHoursPerWeek { get; }
    }
}
