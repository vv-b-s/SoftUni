using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday_Celebrations.Interfaces
{
    public interface IHumanoid:INameable
    {
        string Id { get; set; }
    }
}
