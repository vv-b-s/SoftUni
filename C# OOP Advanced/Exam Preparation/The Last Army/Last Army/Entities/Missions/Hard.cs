using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Hard : Mission
{
    private const double DefaultEnduranceRequired = 80;
    private const double DefaultWearLevelDecrement = 70;

    public Hard(double scoreToComplete) : base(DefaultEnduranceRequired, scoreToComplete)
    {
    }

    public override string Name => "Disposal of terrorists";

    public override double WearLevelDecrement => DefaultWearLevelDecrement;
}
