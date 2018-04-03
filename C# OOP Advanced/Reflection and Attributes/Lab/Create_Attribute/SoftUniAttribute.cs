using System;
using System.Collections.Generic;
using System.Text;

[AttributeUsage(AttributeTargets.Method|AttributeTargets.Class, AllowMultiple = true)]
public class SoftUniAttribute: Attribute
{
    private string name;

    public SoftUniAttribute(string name)
    {
        this.name = name;
    }

    public string Name => this.name;
}