using Military_elite.AbstractClasses;
using Military_elite.ImplementableSoldiers;
using Military_elite.Specialties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Military_elite
{
    public static class SoldierFactory
    {
        public static Soldier CreateSoldier(string[] data, List<Soldier> soldiers)
        {
            var soldierType = data[0];

            var id = data[1];
            var firstName = data[2];
            var lastName = data[3];

            switch (soldierType)
            {
                case "Private": return new Private(id, firstName, lastName, salary: double.Parse(data[4]));

                case "LeutenantGeneral":
                    {
                        var privatesIds = data.Skip(5).ToList();
                        var privates = new List<Private>();

                        foreach (var pId in privatesIds)
                        {
                            var soldier = soldiers.FirstOrDefault(s => s.Id == pId && s is Private);

                            if (soldier != null)
                                privates.Add(soldier as Private);
                        }

                        return new LeutenantGeneral(id, firstName, lastName, salary: double.Parse(data[4]), privates: privates);
                    }

                case "Engineer":
                    {
                        var repairPartsData = data.Skip(6).ToList();
                        var repairParts = new List<RepairPart>();

                        for (int i = 0; i < repairPartsData.Count; i += 2)
                            repairParts.Add(new RepairPart(name: repairPartsData[i], hours: int.Parse(repairPartsData[i + 1])));

                        return new Engineer(id, firstName, lastName, salary: double.Parse(data[4]), corps: data[5], repairParts);
                    }

                case "Commando":
                    {
                        var missionsData = data.Skip(6).ToList();
                        var missions = new List<Mission>();

                        for (int i = 0; i < missionsData.Count; i += 2)
                        {
                            //Catch exception if the mission has incorrect progress
                            try { missions.Add(new Mission(codeName: missionsData[i], progress: missionsData[i + 1])); }
                            catch (ArgumentException) { }
                        }

                        return new Commando(id, firstName, lastName, salary: double.Parse(data[4]), corps: data[5], missions);
                    }

                case "Spy": return new Spy(id, firstName, lastName, int.Parse(data[4]));

                default: return null;
            }
        }
    }
}
