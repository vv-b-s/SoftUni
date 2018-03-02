using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Citizen : IHumanoid
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias">Refers to the human's name</param>
        /// <param name="age"></param>
        /// <param name="id"></param>
        public Citizen(string alias, int age, string id)
        {
            Alias = alias;
            Age = age;
            Id = id;
        }

        public int Age { get; set; }

        /// <summary>
        /// Refers to the human's name
        /// </summary>
        public string Alias { get; set; }

        public string Id { get; set; }
    }
}
