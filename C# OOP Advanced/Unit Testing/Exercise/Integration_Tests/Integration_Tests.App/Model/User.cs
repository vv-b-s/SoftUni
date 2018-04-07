using Integration_Tests.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Tests.App.Model
{
    public class User : IUser
    {
        private HashSet<ICategory> categories;

        public User(string name)
        {
            if (name is null)
                throw new InvalidOperationException("The user must have a name not equal to null!");

            this.Name = name;
            this.categories = new HashSet<ICategory>();
        }

        public string Name { get; private set; }

        public IReadOnlyCollection<ICategory> Categories => this.categories;

        public void AddCategories(params ICategory[] categories)
        {
            if (categories is null || categories.Length == 0)
                throw new ArgumentNullException("At least one category must be provided!");

            foreach(var category in categories)
            {
                if (this.categories.Contains(category))
                    throw new InvalidOperationException("You cannot add repeated categories!");

                this.categories.Add(category);
            }
        }

        public void RemoveCategories(params ICategory[] categories)
        {
            if (categories is null || categories.Length == 0)
                throw new ArgumentNullException("At least one category must be provided!");

            if (this.categories.Count == 0)
                throw new InvalidOperationException("There is nothing to remove!");

            foreach (var category in categories)
                this.categories.Remove(category);

        }
    }
}
