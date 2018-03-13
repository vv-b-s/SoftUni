using System;
using System.Collections.Generic;
using System.Text;

public class HardTyre:Tyre
{
    public HardTyre(double hardness) : base(hardness)
    {
        this.Name = "Hard";
    }
}