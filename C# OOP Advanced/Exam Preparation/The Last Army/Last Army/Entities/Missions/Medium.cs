using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Medium : Mission
{
    private const double DefaultEnduranceRequired = 50;
    private const double DefaultWearLevelDecrement = 50;

    public Medium( double scoreToComplete) : base(DefaultEnduranceRequired, scoreToComplete)
    {
    }

    public override string Name => "Capturing dangerous criminals";

    public override double WearLevelDecrement => DefaultWearLevelDecrement;
}
