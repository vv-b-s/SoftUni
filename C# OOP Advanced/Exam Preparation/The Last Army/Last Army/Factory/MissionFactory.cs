using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        var missionType = Type.GetType(difficultyLevel);
        var mission = Activator.CreateInstance(missionType, neededPoints) as IMission;

        return mission;
    }
}
