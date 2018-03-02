using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday_Celebrations.Interfaces
{
    public interface INameable
    {
        /// <summary>
        /// Refers to the thing's name
        /// </summary>
        string Alias { get; set; }
    }
}
