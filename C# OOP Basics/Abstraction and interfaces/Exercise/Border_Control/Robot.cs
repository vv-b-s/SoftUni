using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Robot : IHumanoid
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias">Refers to the robot's name</param>
        /// <param name="id"></param>
        public Robot(string alias, string id)
        {
            Alias = alias;
            Id = id;
        }

        /// <summary>
        /// Refers to the robot's name
        /// </summary>
        public string Alias { get; set; }

        public string Id { get; set; }
    }
}
