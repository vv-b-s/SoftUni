using Database.App.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Tests
{
    [TestFixture]
    public partial class DatabaseTests
    {
        [Test]
        public void DatabasePeopleShouldHaveUniqueUsernamesAndIdsThrowsIOP()
        {
            var peopleList = this.PersonObjects.ToList();

            var newPerson = new Mock<IPerson>();

            //Check for repeating usernames
            newPerson.Setup(p => p.Name).Returns(peopleList.First().Name);

            CheckForExceptionOnAdding(peopleList, newPerson.Object, "The database accepts repeating usernames.");

            //Check for repeating Ids
            newPerson.Setup(p => p.Name).Returns("Judit");
            newPerson.Setup(p => p.Id).Returns(peopleList.First().Id);

            CheckForExceptionOnAdding(peopleList, newPerson.Object, "The database accepts repeating Ids.");
        }

        [Test]
        public void DatabaseFindByUsernameAndIdWorks()
        {
            var peopleObjects = this.PersonObjects;

            var firstPerson = peopleObjects[0];

            var db = new App.Database(peopleObjects);

            IPerson personByUsername;

            try
            {
                personByUsername = db.FindByUsername(firstPerson.Name);
                Assert.That(personByUsername, Is.EqualTo(firstPerson));
            }
            catch (Exception) { throw new AssertionException("The Database.FindByUsername() does not work properly"); }

            try
            {
                personByUsername = db.FindById(firstPerson.Id);
                Assert.That(personByUsername, Is.EqualTo(firstPerson));
            }
            catch (Exception) { throw new AssertionException("The Database.FindById() does not work properly"); }
        }

        [Test]
        public void DatabaseFindByUsernameOrIdThrowsIOPWhenNotFound()
        {
            var db = new App.Database(this.PersonObjects);

            Assert.That(() => db.FindByUsername("Penka"), Throws.InvalidOperationException, "The database does not throw exceptions when the username is not found.");

            Assert.That(() => db.FindById(500), Throws.InvalidOperationException, "The database does not throw exceptions when the Id is not found");
        }

        [Test]
        public void DatabaseFindByUsernameIsCaseSensitive()
        {
            var peopleObjects = this.PersonObjects;

            var db = new App.Database(peopleObjects);

            var firstUserName = peopleObjects.First().Name.ToLower();

            Assert.That(() => db.FindByUsername(firstUserName), Throws.InvalidOperationException, "The database is case insensitive");
        }

        [Test]
        public void DatabaseFindByUsernameThrowsArgExWhenNull()
        {
            var db = new App.Database();

            Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException, "The Database.FindByUsername accepts null arguments");
        }

        [Test]
        public void DatabaseFindByIdThrowsArgExWhenBelowZero()
        {
            var db = new App.Database();

            try
            {
                db.FindById(-51);
            }
            catch (Exception e)
            {
                Assert.That(e is ArgumentOutOfRangeException, "The thrown exception is incorrect");

                if (e is ArgumentOutOfRangeException)
                    Assert.That(e is ArgumentOutOfRangeException, "The Database.FindById accepts negative ids");
            }
        }

        private void CheckForExceptionOnAdding(List<IPerson> peopleList, IPerson newPerson, string message)
        {
            //Make sure repeating usernames are rejected on creation
            peopleList.Add(newPerson);

            Assert.That(() => new App.Database(peopleList.ToArray()), Throws.InvalidOperationException);

            //Make sure repeating usernames are rejected on addition
            peopleList.Remove(peopleList.Last());

            var db = new App.Database(peopleList.ToArray());

            Assert.That(() => db.Add(newPerson), Throws.InvalidOperationException);
        }
    }
}
