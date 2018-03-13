using System;
using System.Collections.Generic;
using System.Text;

public interface IProvider : IIdentifiable
{
    double EnergyOutput { get; }
}