using Military_elite.AbstractClasses;
using Military_elite.Specialties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Military_elite.ImplementableSoldiers
{
    public class Engineer : SpecialisedSoldier
    {
        private List<RepairPart> repairParts;

        public Engineer(string id, string firstName, string lastName, double salary, string corps, List<RepairPart> repairParts) : base(id, firstName, lastName, salary, corps)
        {
            this.repairParts = repairParts ?? new List<RepairPart>();
        }

        public override string ToString() =>
            $"{base.ToString()}\nRepairs:{string.Join("", repairParts.Select(rp => $"\n{rp}"))}";
    }
}
