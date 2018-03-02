using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday_Celebrations.Interfaces
{
    public interface IBirthable
    {
        string Birthdate { get; set; }

        bool IsBornInYear(int year);
    }
}
