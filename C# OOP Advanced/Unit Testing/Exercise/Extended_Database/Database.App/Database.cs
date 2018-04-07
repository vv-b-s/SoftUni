using Database.App.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.App
{
    public class Database : IDatabase
    {
        private Dictionary<long, string> idUsernames;
        private IPerson[] items = new IPerson[16];

        public Database(params IPerson[] people)
        {
            if (people.Length > 16)
                throw new InvalidOperationException("Insufficient memory!");

            else
            {
                if (this.idUsernames is null)
                    this.idUsernames = new Dictionary<long, string>();

                this.LastIndex = - 1;
                this.NumberOfStoredItems = 0;

                this.items = new IPerson[16];

                for (int i = 0; i < people.Length; i++)
                    this.Add(people[i]);
            }
        }

        public int NumberOfStoredItems { get; private set; }

        public int Capcaity => items.Length;

        public int LastIndex { get; private set; }

        public void Add(IPerson person)
        {
            if (this.NumberOfStoredItems >= 16)
                throw new InvalidOperationException("Insufficient memory!");

            else
            {
                if (this.idUsernames.ContainsKey(person.Id) || this.idUsernames.ContainsValue(person.Name))
                    throw new InvalidOperationException("A person with the same Id/Username already exists!");



                else
                {
                    this.idUsernames[person.Id] = person.Name;

                    this.LastIndex++;
                    this.NumberOfStoredItems++;

                    this.items[LastIndex] = person;
                }
            }

        }

        public IPerson[] Fetch()
        {
            return this.items;
        }

        public IPerson FindById(long id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException("The given Id cannot be negative");

            var person = this.items.FirstOrDefault(i => i.Id == id);

            if (person is null)
                throw new InvalidOperationException("Person not found!");

            else return person;
        }

        public IPerson FindByUsername(string username)
        {
            if (username is null)
                throw new ArgumentNullException("The username cannot be null!");

            var person = this.items.FirstOrDefault(p => p.Name == username);

            if(person is null)
                throw new InvalidOperationException("Person not found!");

            return person;
        }

        public IPerson Remove()
        {
            if (this.NumberOfStoredItems == 0)
                throw new InvalidOperationException("The database is empty!");

            else
            {
                var removedValue = this.items[LastIndex];

                this.items[LastIndex] = default(IPerson);

                this.LastIndex--;
                this.NumberOfStoredItems--;

                return removedValue;
            }
        }
    }
}
