using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    sealed class InjectAttribute : Attribute
    {
        readonly string dependencyName;
        public InjectAttribute(string dependencyName)
        {
            this.dependencyName = dependencyName;
        }

        public string DependencyName
        {
            get { return dependencyName; }
        }
    }
}
