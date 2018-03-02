using Birthday_Celebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday_Celebrations
{
    public class Pet : LivingEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias">Refers to the name of the pet</param>
        /// <param name="birthdate"></param>
        public Pet(string alias, string birthdate) : base(alias, birthdate) { }
    }
}
