using Iterator_Test.App;
using NUnit.Framework;
using System;
using System.Linq;

namespace Iterator_Test.Tests
{
    [TestFixture]
    public class ListIteratorTests
    {
        private ListIterator<string> li;
        private string[] listIteratorDefaultItems = { "Eat", "Ate", "Eaten", "Break", "Broke", "Broken" };

        [SetUp]
        public void Init()
        {
            this.li = new ListIterator<string>(listIteratorDefaultItems);
        }

        [Test]
        public void ListIteratorInitializesItemsThroughConstructor()
        {
            var type = typeof(ListIterator<int>);

            try
            {
                var constructor = type.GetConstructor(new Type[] { typeof(int[]) });
                var constructorParameters = constructor.GetParameters();

                Assert.That(constructorParameters.All(cp => cp.ParameterType == typeof(int[])), "Constructor takes variables not suitable for the task.");
            }
            catch (Exception e)
            {
                if (e is AssertionException)
                    throw;

                else throw new AssertionException("Wrong constructor!");
            }

        }

        [Test]
        public void ListIteratorMoveShouldMoveItemWithOneIndex()
        {
            var expetedInitialItem = this.listIteratorDefaultItems[0];
            var listInitialItem = this.li.Print();

            Assert.That(expetedInitialItem, Is.EqualTo(listInitialItem), "The list starts from a wrong index");

            var expectedNextItem = this.listIteratorDefaultItems[1];

            this.li.Move();

            var listCurrentItem = this.li.Print();

            Assert.That(expectedNextItem, Is.EqualTo(listCurrentItem));
        }

        [Test]
        public void ListIteratorMoveAndHasNextShouldReturnTrueUntillTheEndOfTheList()
        {
            for (int i = 0; i < this.listIteratorDefaultItems.Length - 1; i++)
            {
                Assert.That(this.li.HasNext(),"ListIterator.HasNext() should return true but returns false.");
                Assert.That(this.li.Move(), "ListIterator.Move() should return true but returns false.");
            }

            Assert.That(!li.HasNext(), "ListIterator.HasNext() should return false but returns true.");
            Assert.That(!this.li.Move(), "ListIterator.Move() should return false but returns true.");
        }

        [Test]
        public void ListIteratorShouldPrintItsCurrentItem()
        {
            var expetedItem = this.listIteratorDefaultItems[0];
            var currentItem = this.li.Print();

            Assert.That(expetedItem, Is.EqualTo(currentItem));
        }

        [Test]
        public void ListIteratorEmptyCollectionShouldThrowIOP()
        {
            var empty = new ListIterator<int>();

            Assert.That(() => empty.Print(), Throws.InvalidOperationException);
        }
    }
}
