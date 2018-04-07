using Integration_Tests.App.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration_Tests.App.Model
{
    public class Category : ICategory
    {
        private HashSet<IUser> users;
        private HashSet<ICategory> categories;

        public Category(string name)
        {
            if (name is null)
                throw new ArgumentNullException("The given name cannot be null.");

            this.Name = name;
            this.users = new HashSet<IUser>();
            this.categories = new HashSet<ICategory>();
        }

        public string Name { get; private set; }

        public IReadOnlyCollection<IUser> Users => this.users;

        public IReadOnlyCollection<ICategory> Subcategories => this.categories;

        public void AddSubcategories(params ICategory[] categories)
        {
            if (categories.Length == 0 || categories is null)
                throw new ArgumentNullException("There must be at least one category added!");

            if (categories.Any(c => c == this))
                throw new InvalidOperationException("You cannot add the same category to itself");

            foreach (var category in categories)
            {
                if(this.categories.Contains(category))
                    throw new InvalidOperationException("One or more categories repeat!");

                //If any of the categories contain its parent as subcategory
                if (category.Subcategories.Contains(this))
                    throw new InvalidOperationException("You cannot add parent categroy as a subcategory to the child!");

                this.categories.Add(category);
            }
        }

        public void AddUsers(params IUser[] users)
        {
            if (users.Length == 0 || users is null)
                throw new ArgumentNullException("There must be at least one user added!");

            foreach (var user in users)
            {
                if(this.users.Any(u=>u.Name==user.Name))
                    throw new InvalidOperationException("One or more users/usernames repeat!");

                this.users.Add(user);
                user.AddCategories(this);
            }
        }

        public void RemoveCategory()
        {
            if (this.users.Any(u => u.Categories.Count == 1))
                throw new InvalidOperationException("There are users linked only to this category. Category cannot be removed!");

            else
            {
                foreach (var user in users)
                    user.RemoveCategories(this);
            }
        }

        public void RemoveSubcategories(params ICategory[] categories)
        {
            if (categories.Length == 0 || categories is null)
                throw new ArgumentNullException("You must geve at least one category as argument");

            if (this.categories.Count == 0)
                throw new InvalidOperationException("There's no categories to remove");

            foreach (var category in categories)
            {
                if (this.categories.Contains(category))
                    this.categories.Remove(category);
            }
        }
    }
}
