using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Easy : Mission
{
    private const double DefaultEnduranceRequired = 20;
    private const double DefaultWearLevelDecrement = 30;

    public Easy(double scoreToComplete) : base(DefaultEnduranceRequired, scoreToComplete)
    {
    }

    public override string Name => "Suppression of civil rebellion";

    public override double WearLevelDecrement => DefaultWearLevelDecrement;
}
