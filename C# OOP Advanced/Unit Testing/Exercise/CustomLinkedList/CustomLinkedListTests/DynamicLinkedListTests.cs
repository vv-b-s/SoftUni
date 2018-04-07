using CustomLinkedList;
using NUnit.Framework;
using System;
using System.Linq;

namespace CustomLinkedListTests
{
    [TestFixture]
    public class DynamicLinkedListTests
    {
        private DynamicList<int> dlist;
        private int randomIndex;
        private int[] sampleItems = { 2, 3, 8, 4, 5 };

        [SetUp]
        public void Init()
        {
            this.dlist = new DynamicList<int>();
            this.randomIndex = new Random().Next(this.sampleItems.Length);
        }

        [Test]
        public void DynamicLinkedListCountsAcurately()
        {
            this.InitializeSampleItems();

            var countAfterItemInitialization = this.dlist.Count;

            this.dlist.Remove(this.sampleItems.Last());
            var countAfterFirstRemoval = this.dlist.Count;

            this.dlist.RemoveAt(0);
            var countAfterSecondRemoval = this.dlist.Count;

            Assert.That(countAfterItemInitialization, Is.EqualTo(this.sampleItems.Length), "Count doesn't increment correctly!");
            Assert.That(countAfterFirstRemoval, Is.EqualTo(this.sampleItems.Length - 1), "Remove() does not decrement Count properly");
            Assert.That(countAfterSecondRemoval, Is.EqualTo(this.sampleItems.Length - 2), "RemoveAt() does not decrement Count properly");

        }

        [Test]
        public void DynamicLinkedListInitializesWithSizeOfZero()
        {
            Assert.That(this.dlist.Count == 0, "The list does not initialize with the count of Zero");
        }

        [Test]
        public void DynamicLinkedListAddAddsItems()
        {
            var sizeBeforeAddition = this.dlist.Count;

            this.dlist.Add(15);

            var sizeAfterAffition = this.dlist.Count;

            Assert.That(sizeBeforeAddition, Is.LessThan(sizeAfterAffition), "The list does not add items!");
        }

        [Test]
        public void DynamicLinkedListIndexingGetsValuePeoperly()
        {
            InitializeSampleItems();

            var expecterNumber = this.sampleItems[randomIndex];

            Assert.That(this.dlist[randomIndex], Is.EqualTo(expecterNumber), "The index does not point to the desired item");
        }

        [Test]
        public void DynamicLinkedListIndexingSetsValueProperly()
        {
            InitializeSampleItems();

            var valueToChange = 6;

            this.dlist[randomIndex] = valueToChange;

            Assert.That(valueToChange, Is.EqualTo(this.dlist[randomIndex]), "The value setter for the list doesn not work properly");
        }

        [Test]
        public void DynamicLinkedListIndexOfWorks()
        {
            InitializeSampleItems();

            var randomItem = this.sampleItems[randomIndex];

            Assert.That(this.dlist.IndexOf(randomItem), Is.EqualTo(randomIndex), "IndexOf does not give the exact index of the desired item");
        }

        [Test]
        public void DynamicLinkedListThrowsAORExceptionWhenPassingInvalidIndex()
        {
            InitializeSampleItems();

            var argumentOEWasThrown = new bool[2];

            try { var value = this.dlist[-53]; }
            catch (Exception e)
            {
                if (e is ArgumentOutOfRangeException)
                    argumentOEWasThrown[0] = true;

                else
                    throw new AssertionException("Passing index over the length-1 does not throw exception!");
            }

            try { var value = this.dlist[this.sampleItems.Length + 15]; }
            catch (Exception e)
            {
                if (e is ArgumentOutOfRangeException)
                    argumentOEWasThrown[1] = true;
                else
                    throw new AssertionException("Passing index over under 0 does not throw exception!");
            }

            Assert.That(argumentOEWasThrown.All(aoe => aoe == true), "The ArgumenOutOfRangeException was not thrown as expected!");
        }

        [Test]
        public void DynamicLinkedListRemoveAtAndRemoveWorksCorrectly()
        {
            InitializeSampleItems();

            var expectedItemToBeRemoved = this.sampleItems[randomIndex];

            this.dlist.RemoveAt(randomIndex);

            Assert.That(!this.dlist.Contains(expectedItemToBeRemoved), "RemoveAt() does not work properly!");
        }

        [Test]
        public void DynamicLinkedListRemoveAtThrowsAORException()
        {
            InitializeSampleItems();

            var argumentOEWasThrown = new bool[2];

            try { this.dlist.RemoveAt(-512); }
            catch (Exception e)
            {
                if (e is ArgumentOutOfRangeException)
                    argumentOEWasThrown[0] = true;

                else
                    throw new AssertionException("Passing index over the length-1 does not throw exception!");
            }

            try { this.dlist.RemoveAt(this.dlist.Count + 131); }
            catch (Exception e)
            {
                if (e is ArgumentOutOfRangeException)
                    argumentOEWasThrown[1] = true;
                else
                    throw new AssertionException("Passing index under 0 does not throw exception!");
            }

            Assert.That(argumentOEWasThrown.All(aoe => aoe == true), "The ArgumenOutOfRangeException was not thrown as expected!");
        }

        [Test]
        public void DynamicLinkedListRemoveWorksCorrectly()
        {
            InitializeSampleItems();

            var itemToRemove = this.sampleItems[randomIndex];

            this.dlist.Remove(itemToRemove);

            Assert.That(!this.dlist.Contains(itemToRemove), "Remove() does not work properly!");

        }


        private void InitializeSampleItems()
        {
            foreach (var item in this.sampleItems)
                this.dlist.Add(item);
        }
    }
}
