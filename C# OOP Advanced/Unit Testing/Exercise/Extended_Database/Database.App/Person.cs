using Database.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.App
{
    public class Person : IPerson
    {
        private static long id = 0;

        public Person(string name)
        {
            this.Id = id;
            this.Name = name;

            id++;
        }

        public long Id { get; private set; }

        public string Name { get; set; }
    }
}
