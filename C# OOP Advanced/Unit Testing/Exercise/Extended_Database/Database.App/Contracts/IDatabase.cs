using System;
using System.Collections.Generic;
using System.Text;

namespace Database.App.Contracts
{
    public interface IDatabase
    {
        void Add(IPerson person);

        IPerson Remove();

        int NumberOfStoredItems { get; }

        int LastIndex { get; }

        int Capcaity { get; }

        IPerson[] Fetch();

        IPerson FindByUsername(string username);

        IPerson FindById(long id);
    }
}
