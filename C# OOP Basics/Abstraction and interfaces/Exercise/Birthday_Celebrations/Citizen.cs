using Birthday_Celebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday_Celebrations
{
    public class Citizen : LivingEntity, IHumanoid
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias">Refers to the human's name</param>
        /// <param name="age"></param>
        /// <param name="id"></param>
        public Citizen(string alias, int age, string id, string birthDate) : base(alias, birthDate)
        {
            Age = age;
            Id = id;
        }

        public int Age { get; set; }

        public string Id { get; set; }
    }
}
