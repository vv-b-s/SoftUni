using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HeroCommand : Command
{
    public HeroCommand(IList<string> arguments, IManager manager) : base(arguments, manager)
    {
    }

    public override string Execute()
    {
        var heroName = this.Arguments[0];
        var heroType = this.Arguments[1];

        var result = Manager.AddHero(heroName, heroType);
        return result;
    }
}
