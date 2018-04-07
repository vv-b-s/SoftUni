using System;
using System.Collections.Generic;
using System.Text;

namespace Database.App.Contracts
{
    public interface IDatabase
    {
        void Add(int integer);

        int Remove();

        int NumberOfStoredItems { get; }

        int LastIndex { get; }

        int Capcaity { get; }

        int[] Fetch();
    }
}
