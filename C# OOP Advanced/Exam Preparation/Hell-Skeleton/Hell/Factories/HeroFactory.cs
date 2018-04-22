using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HeroFactory : IHeroFactory
{
    public IHero CreateHero(string name, string heroTypeName)
    {
        var heroType = Type.GetType(heroTypeName);
        var heroInstance = Activator.CreateInstance(heroType, name) as IHero;

        return heroInstance;
    }
}
