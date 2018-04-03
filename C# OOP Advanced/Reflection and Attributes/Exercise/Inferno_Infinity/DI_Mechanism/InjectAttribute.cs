using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Infinity.DI_Mechanism
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    sealed class InjectAttribute : Attribute
    {
        public InjectAttribute()
        {
            
        }
    }
}
