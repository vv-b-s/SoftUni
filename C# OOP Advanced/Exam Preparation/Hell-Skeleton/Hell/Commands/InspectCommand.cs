using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InspectCommand : Command
{
    public InspectCommand(IList<string> arguments, IManager manager) : base(arguments, manager)
    {
    }

    public override string Execute()
    {
        var heroName = Arguments[0];
        var result = Manager.Inspect(heroName);

        return result;
    }
}