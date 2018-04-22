using System;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        var ammunitionType = Type.GetType(ammunitionName);

        var ammunition = Activator.CreateInstance(ammunitionType, ammunitionName) as IAmmunition;

        return ammunition;
    }
}