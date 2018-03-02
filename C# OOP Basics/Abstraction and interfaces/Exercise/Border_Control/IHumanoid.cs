using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public interface IHumanoid
    {
        /// <summary>
        /// Refers to the humanoid's name
        /// </summary>
        string Alias { get; set; }

        string Id { get; set; }
    }
}
