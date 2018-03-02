using Birthday_Celebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday_Celebrations
{
    public abstract class LivingEntity : INameable, IBirthable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias">Refers to the entity's name</param>
        /// <param name="birthDate"></param>
        public LivingEntity(string alias, string birthDate)
        {
            Alias = alias;
            Birthdate = birthDate;
        }

        /// <summary>
        /// Refers to the name of the entity
        /// </summary>
        public string Alias { get; set; }

        public string Birthdate { get; set; }

        public bool IsBornInYear(int year)
        {
            var lastSlash = Birthdate.LastIndexOf('/');
            var birthYear = int.Parse(Birthdate.Substring(lastSlash+1));

            return year == birthYear;
        }
    }
}
