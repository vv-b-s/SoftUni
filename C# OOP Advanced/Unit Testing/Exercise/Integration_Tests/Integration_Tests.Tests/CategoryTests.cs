using Integration_Tests.App.Contracts;
using Integration_Tests.App.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration_Tests.Tests
{
    [TestFixture]
    public class CategoryTests
    {
        private const int AmountOfDummyEntities = 10;

        private Category[] categories;
        private IUser[] dummyUsers;

        [SetUp]
        public void Init()
        {
            this.categories = new Category[AmountOfDummyEntities];
            this.dummyUsers = new IUser[AmountOfDummyEntities];

            for (int i = 0; i < AmountOfDummyEntities; i++)
                categories[i] = new Category($"Category{i}");

            for (int i = 0; i < AmountOfDummyEntities; i++)
                dummyUsers[i] = CreateUserMock(i, "John");
        }

        [Test]
        public void CategoryNameShouldNotBeNull() =>
            Assert.That(() => new Category(null), Throws.ArgumentNullException, "The category name allows to be null");

        [Test]
        public void CategoryAddCategoriesWorks()
        {
            var category = new Category("Parent");

            foreach (var subcategory in this.categories)
                category.AddSubcategories(subcategory);

            Assert.That(Enumerable.SequenceEqual(this.categories, category.Subcategories), "The added categories missmatch");
        }

        [Test]
        public void CategoryChildAddShouldNotAddItsParentAndThrowsIOP()
        {
            var demoCategory = this.categories[0];
            demoCategory.AddSubcategories(this.categories.Skip(1).ToArray());

            var childCategory = this.categories[1];

            Assert.That(() => childCategory.AddSubcategories(demoCategory), Throws.InvalidOperationException);
        }

        [Test]
        public void CategoryAddSubcategoryShouldThrowIOPWhenRepeating()
        {
            var category = new Category("Crashing one");

            category.AddSubcategories(this.categories);
            var repeatedCategory = this.categories.First();

            Assert.That(() => category.AddSubcategories(repeatedCategory),
                Throws.InvalidOperationException, "The category.AddCategories() method accepts repeating entities");
        }

        [Test]
        public void CategoryAddRemoveMethodsShouldThrowIOPWhenNullArgumentsArePassed()
        {
            var category = this.categories[0];

            Assert.That(() => category.AddSubcategories(),
                Throws.ArgumentNullException, "The Category.AddSubcategories() accepts empty arguments");

            Assert.That(() => category.AddUsers(), Throws.ArgumentNullException,
                "The Category.AddUsers() accepts empty arguments");

            Assert.That(() => category.RemoveSubcategories(), Throws.ArgumentNullException,
                "The method Category.RemoveSubcategories() accepts null arguments");
        }

        [Test]
        public void CategoryAddUsersWorks()
        {
            var demoCategory = new Category("Demooooooo!");

            demoCategory.AddUsers(this.dummyUsers);

            Assert.That(Enumerable.SequenceEqual(demoCategory.Users, this.dummyUsers), "Users don't add properly.");
        }

        [Test]
        public void CategoryAddUsersAddsTheCategoryToTheUser()
        {
            var category = this.categories[0];
            var demoUser = new User("Unadded");

            category.AddUsers(demoUser);

            Assert.That(demoUser.Categories.Contains(category));
        }

        [Test]
        public void CategoryAddUsersShoudNotAddRepeatingUsers()
        {
            var demoCategory = this.categories[0];

            Assert.That(() => demoCategory.AddUsers(dummyUsers[0], dummyUsers[0]), Throws.InvalidOperationException);
        }

        [Test]
        public void CategoryRemoveCategoriesThrowsIOPWhenAUserHasNoMoreThanOneCategories()
        {
            var demoCategory = this.categories[0];

            var userMock = new Mock<IUser>();
            userMock.Setup(u => u.Categories).Returns(new ICategory[] { demoCategory });
            demoCategory.AddUsers(userMock.Object);

            Assert.That(() => demoCategory.RemoveCategory(), Throws.InvalidOperationException,
                "Category.Remove(). Allows removel even though there are users linked only to this category.");
        }

        [Test]
        public void RemoveCategoriesThrowsIOPWhenThereAreNoSubcategories()
        {
            var demoCategory = this.categories[0];

            Assert.That(() => demoCategory.RemoveSubcategories(categories[1]), Throws.InvalidOperationException);
        }

        private IUser CreateUserMock(int identifier, string username)
        {

            var user = new User($"{username}{identifier}");

            var rand = new Random();

            var setOfCategories = new ICategory[3];


            for (int i = 0; i < 3; i++)
            {
                var randomCategory = this.categories[rand.Next(1, AmountOfDummyEntities)];

                if (setOfCategories.Contains(randomCategory)) i--;

                else setOfCategories[i] = randomCategory;
            }

            user.AddCategories(setOfCategories);

            return user;
        }
    }
}
