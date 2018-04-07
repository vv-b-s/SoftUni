using Bubble_Sort_Test.App;
using NUnit.Framework;
using System;
using System.Linq;

namespace Bubble_Sort_Test.Tests
{
    [TestFixture]
    public class BubbleTests
    {
        private int[] randomElements = { 3, 8, 9, 10, 5, 15, 6, 1, 7 };

        [Test]
        public void BubbleElementsAreCorrectlySorted()
        {
            var elementsSortedByDotNet = randomElements.OrderBy(n => n);

            var elementsSortedByBubble = Bubble.Sort(randomElements);

            Assert.That(Enumerable.SequenceEqual(elementsSortedByDotNet, elementsSortedByBubble), $"The bubble sorting does not work properly.\n" +
                $"Test elements appear as {string.Join(" ", randomElements)}");
        }
    }
}
