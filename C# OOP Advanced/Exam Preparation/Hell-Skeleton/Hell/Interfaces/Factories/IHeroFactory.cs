using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IHeroFactory
{
    IHero CreateHero(string name, string heroTypeName);
}
