using Integration_Tests.App.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration_Tests.Tests
{
    [TestFixture]
    public class UserTests
    {
        private const int DefaultCountOfDummies = 10;

        private User userInstance;
        private Category category;

        [SetUp]
        public void Init()
        {
            this.userInstance = new User("Pesho-Ke$ho");
            this.category = new Category("Kateto");
        }

        [Test]
        public void UserTakesUsernameNotEqualToNull() =>
            Assert.That(() => new User(null), Throws.InvalidOperationException);

        [Test]
        public void UserAddCategoriesIsWorking()
        {
            this.userInstance.AddCategories(this.category);

            var addedCategory = userInstance.Categories.First();

            Assert.That(category, Is.EqualTo(addedCategory), "There is a missmatch in the category addition.");
        }

        [Test]
        public void UserAddCategoriesDoesNotRepeatEntries()
        {
            var category2 = this.category;

            this.userInstance.AddCategories(this.category);

            Assert.That(() => this.userInstance.AddCategories(category2), Throws.InvalidOperationException);
        }

        [Test]
        public void UserAddRemoveCategoriesDoNotTakeEmptyArguments()
        {
            Assert.That(() => this.userInstance.AddCategories(), Throws.ArgumentNullException, "User.AddCategories() takes empty arguments!");

            Assert.That(() => this.userInstance.AddCategories(null), Throws.ArgumentNullException, "User.AddCategories() takes null arguments!");

            Assert.That(() => this.userInstance.RemoveCategories(), Throws.ArgumentNullException, "User.RemoveCategories() takes empty arguments!");

            Assert.That(() => this.userInstance.RemoveCategories(null), Throws.ArgumentNullException, "User.RemoveCategories() takes null arguments!");
        }

        [Test]
        public void UserRemoveCategoriesWorks()
        {
            this.userInstance.AddCategories(this.category);

            var countOfCategoriesBeforeRemoval = this.userInstance.Categories.Count;

            this.userInstance.RemoveCategories(category);

            var countOfCategoriesAfterRemoval = this.userInstance.Categories.Count;

            Assert.That(countOfCategoriesAfterRemoval, Is.LessThan(countOfCategoriesBeforeRemoval), "Categories don't remove properly");
        }

        [Test]
        public void UserRemoveCategoriesThrowsExceptionWhenThereIsNothingToRemove() =>
            Assert.That(() => userInstance.RemoveCategories(category), Throws.InvalidOperationException);
    }
}
