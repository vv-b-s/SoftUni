using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator_Test.App
{
    public class ListIterator<T> : IListIterator<T>
    {
        private List<T> items;

        private int currentPosition = 0;

        public ListIterator(params T[] items)
        {
            this.items = new List<T>(items);
        }

        public bool HasNext()
        {
            return this.currentPosition < this.items.Count - 1;
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.currentPosition++;
                return true;
            }

            else return false;
        }

        public T Print()
        {
            if (this.items.Count == 0)
                throw new InvalidOperationException("Invalid Operation!");

            else return this.items[currentPosition];
        }
    }
}
