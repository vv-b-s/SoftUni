using Database.App.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Database.App
{
    public class Database : IDatabase
    {
        private int[] items = new int[16];

        public Database(params int[] integers)
        {
            if (integers.Length > 16)
                throw new InvalidOperationException("Insufficient memory!");

            else
            {
                this.LastIndex = integers.Length - 1;
                this.NumberOfStoredItems = integers.Length;

                this.items = new int[16];

                Array.Copy(integers, this.items, integers.Length);
            }
        }

        public int NumberOfStoredItems { get; private set; }

        public int Capcaity => items.Length;

        public int LastIndex { get; private set; }

        public void Add(int integer)
        {
            if (this.NumberOfStoredItems >= 16)
                throw new InvalidOperationException("Insufficient memory!");

            else
            {
                this.LastIndex++;
                this.NumberOfStoredItems++;

                this.items[LastIndex] = integer;
            }

        }

        public int[] Fetch()
        {
            return this.items;
        }

        public int Remove()
        {
            if (this.NumberOfStoredItems == 0)
                throw new InvalidOperationException("The database is empty!");

            else
            {
                var removedValue = this.items[LastIndex];

                this.items[LastIndex] = 0;

                this.LastIndex--;
                this.NumberOfStoredItems--;

                return removedValue;
            }
        }

    }
}
