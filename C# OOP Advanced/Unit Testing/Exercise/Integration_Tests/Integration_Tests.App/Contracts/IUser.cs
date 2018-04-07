using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Tests.App.Contracts
{
    public interface IUser
    {
        string Name { get; }

        IReadOnlyCollection<ICategory> Categories { get; }

        void AddCategories(params ICategory[] categories);
        void RemoveCategories(params ICategory[] categories);
    }
}
