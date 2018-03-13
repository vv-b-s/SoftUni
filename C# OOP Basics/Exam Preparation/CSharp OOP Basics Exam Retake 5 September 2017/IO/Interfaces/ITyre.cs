using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ITyre
{
    string Name { get; }
    double Hardness { get; }
    double Degradation { get; }
}