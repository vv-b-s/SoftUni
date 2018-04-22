using System.Collections.Generic;

public interface IWareHouse
{
    IReadOnlyDictionary<string, IList<IAmmunition>> Ammunitions { get; }

    void AddAmmunitions(IAmmunition ammunition);

    void RemoveAmmunition(IAmmunition ammunition);

    void EquipArmy(IArmy army);
}