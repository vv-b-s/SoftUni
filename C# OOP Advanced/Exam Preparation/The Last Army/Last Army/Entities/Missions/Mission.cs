using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Mission : IMission
{
    protected Mission(double enduranceRequired, double scoreToComplete)
    {
        this.EnduranceRequired = enduranceRequired;
        this.ScoreToComplete = scoreToComplete;
    }
    
    public abstract string Name { get; }

    public double EnduranceRequired { get; protected set; }

    public double ScoreToComplete { get; protected set; }

    public abstract double WearLevelDecrement { get; }
}