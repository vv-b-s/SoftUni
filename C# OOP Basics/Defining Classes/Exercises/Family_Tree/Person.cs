using System;
using System.Collections.Generic;
using System.Text;

namespace Family_Tree
{
    public class Person
    {
        public string Name { get; set; }
        public string Birthdate { get; set; }

        public List<Person> Parents { get; set; }
        public List<Person> Children { get; set; }

        public Person()
        {
            Parents = new List<Person>();
            Children = new List<Person>();
        }

        /// <summary>
        /// Recognizes if the detail is a birthdate or Name and adds the detail to the member
        /// </summary>
        /// <param name="detail"></param>
        public void AddMemberDetail(string detail)
        {
            if (detail.Contains("/"))
                Birthdate = detail;
            else
                Name = detail;
        }

        public override string ToString() => $"{Name} {Birthdate}";
    }
}
