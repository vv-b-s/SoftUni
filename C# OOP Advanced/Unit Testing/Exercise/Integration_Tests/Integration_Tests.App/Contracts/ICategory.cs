using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Tests.App.Contracts
{
    public interface ICategory
    {
        string Name { get; }
        IReadOnlyCollection<IUser> Users { get; }
        IReadOnlyCollection<ICategory> Subcategories { get; }

        void AddUsers(params IUser[] users);
        void AddSubcategories(params ICategory[] categories);
        void RemoveCategory();
        void RemoveSubcategories(params ICategory[] categories);
    }
}
