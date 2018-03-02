using Military_elite.AbstractClasses;
using Military_elite.Specialties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Military_elite.ImplementableSoldiers
{
    public class Commando : SpecialisedSoldier
    {
        private List<Mission> missions;

        public Commando(string id, string firstName, string lastName, double salary, string corps, List<Mission> missions) : base(id, firstName, lastName, salary, corps)
        {
            this.missions = missions ?? new List<Mission>();
        }

        public override string ToString() => $"{base.ToString()}\nMissions:{string.Join("", missions.Select(m=> $"\n{m}"))}";
    }
}
