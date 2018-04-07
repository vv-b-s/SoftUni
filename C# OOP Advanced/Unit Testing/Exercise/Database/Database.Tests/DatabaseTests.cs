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
    public class DatabaseTests
    {

        [Test]
        public void DatabaseCapacityIsExactly16()
        {
            var db = new App.Database();


            Assert.That(db.Capcaity, Is.EqualTo(16), $"Database.Capacity is not equal to 16! Current value: {db.Capcaity}");
            Assert.That(db.Fetch().Length, Is.EqualTo(16), "Database.Fetch returns array not equal to 16!");
        }

        [Test]
        public void DtabaseShouldThrowInvalidOperationExceptionWhenIntegersAreNot16()
        {
            Assert.That(() => new App.Database(new int[17]), Throws.InvalidOperationException);
        }

        [Test]
        public void DatabaseShouldThrowInvalidOperationExceptionIfOverflows16()
        {
            var db = new App.Database(new int[16]);

            Assert.That(() => db.Add(1), Throws.InvalidOperationException);
        }

        [Test]
        public void DatabaseElementsAreAddedInLIFOOrder()
        {
            var db = new App.Database(1, 8);

            var addedItem = 5;
            db.Add(addedItem);

            var lastItem = db.Fetch()[db.LastIndex];

            Assert.That(lastItem, Is.EqualTo(addedItem), "The adding order is not LIFO!");
        }

        [Test]
        public void DatabaseElementsAreRemovedInLIFOOrder()
        {
            var db = new App.Database(1, 2, 3);

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
        public void DatabaseConstructorShouldTakeOnlyIntegers()
        {
            var constructor = typeof(App.Database).GetConstructor(new Type[] { typeof(int[]) });

            Assert.That(constructor.GetParameters().All(p => p.ParameterType == typeof(int[]) || p.ParameterType == typeof(int)),
                "Cunstructor parameters must take only integer values!");
        }

        [Test]
        public void DatabaseConstructorStoresValuesInArray()
        {
            var defaultArray = new int[] { 3, 2, 1, 8, 7 };

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
        public void DatabaseFetchElementsIntegerIsArray()
        {
            var fetchMethod = typeof(App.Database).GetMethod("Fetch");

            Assert.That(fetchMethod.ReturnType, Is.EqualTo(typeof(int[])), $"Fetch method is of type {fetchMethod.ReturnType} but not {typeof(int[])}");
        }
    }
}
