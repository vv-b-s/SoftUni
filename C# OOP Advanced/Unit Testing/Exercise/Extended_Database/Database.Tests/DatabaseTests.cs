using NUnit.Framework;
using Database.App;
using System;
using Moq;
using Database.App.Contracts;
using System.Reflection;
using System.Linq;

namespace Database.Tests
{
    [TestFixture]
    public partial class DatabaseTests
    {
        private const int DefaultNumberOfPeople = 16;

        private Mock<IPerson>[] people;

        private IPerson[] PersonObjects => this.people.Select(p => p.Object).ToArray();

        [SetUp]
        public void Init()
        {
            this.people = new Mock<IPerson>[DefaultNumberOfPeople];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Mock<IPerson>();

                people[i].Setup(p => p.Id).Returns(i + 1);
                people[i].Setup(p => p.Name).Returns($"John{i}");
            }
        }


        [Test]
        public void DatabaseCapacityIsExactly16()
        {
            var db = new App.Database();


            Assert.That(db.Capcaity, Is.EqualTo(16), $"Database.Capacity is not equal to 16! Current value: {db.Capcaity}");
            Assert.That(db.Fetch().Length, Is.EqualTo(16), "Database.Fetch returns array not equal to 16!");
        }

        [Test]
        public void DtabaseShouldThrowInvalidOperationExceptionWhenPeopleAreOver16()
        {
            Assert.That(() => new App.Database(new IPerson[17]), Throws.InvalidOperationException);
        }

        [Test]
        public void DatabaseShouldThrowInvalidOperationExceptionIfOverflows16()
        {
            var db = new App.Database(this.PersonObjects);

            Assert.That(() => db.Add(this.people[0].Object), Throws.InvalidOperationException);
        }

        [Test]
        public void DatabaseElementsAreAddedInLIFOOrder()
        {
            var peopleArray = this.PersonObjects;

            var db = new App.Database(peopleArray[0], peopleArray[1]);

            var addedItem = peopleArray[2];

            db.Add(addedItem);

            var lastItem = db.Fetch()[db.LastIndex];

            Assert.That(lastItem, Is.EqualTo(addedItem), "The adding order is not LIFO!");
        }

        [Test]
        public void DatabaseElementsAreRemovedInLIFOOrder()
        {
            var db = new App.Database(this.PersonObjects);

            var lastElement = db.Fetch()[db.LastIndex];

            db.Remove();

            var lastElementAfterRemoval = db.Fetch()[db.LastIndex];

            Assert.That(lastElement, Is.Not.EqualTo(lastElementAfterRemoval), "The removal is either not in LIFO order or the element had not been removed");
        }

        [Test]
        public void DatabaseEmptyArrayRemovalResultsInIOPException()
        {
            var db = new App.Database();

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void DatabaseConstructorShouldTakeOnlyPeople()
        {
            var constructor = typeof(App.Database).GetConstructor(new Type[] { typeof(IPerson[]) });

            Assert.That(constructor.GetParameters().All(p => p.ParameterType == typeof(IPerson[]) || p.ParameterType == typeof(IPerson)),
                "Cunstructor parameters must take only integer values!");
        }

        [Test]
        public void DatabaseConstructorStoresValuesInArray()
        {
            var defaultArray = this.PersonObjects;

            var db = new App.Database(defaultArray);

            var fetchedArray = db.Fetch();

            var elementsAreSaved = true;
            for (int i = 0; i < defaultArray.Length; i++)
            {
                if (defaultArray[i] != fetchedArray[i])
                {
                    elementsAreSaved = false;
                    break;
                }
            }

            Assert.That(elementsAreSaved, "There was a missmatch when checking saved elements. Make sure they are saved correctly!");
        }

        [Test]
        public void DatabaseFetchElementsPersonIsArray()
        {
            var fetchMethod = typeof(App.Database).GetMethod("Fetch");

            Assert.That(fetchMethod.ReturnType, Is.EqualTo(typeof(IPerson[])), $"Fetch method is of type {fetchMethod.ReturnType} but not {typeof(IPerson[])}");
        }
    }
}
