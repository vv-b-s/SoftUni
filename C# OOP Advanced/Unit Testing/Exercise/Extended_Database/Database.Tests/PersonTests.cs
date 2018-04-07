using Database.App;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Tests
{
    [TestFixture]
    class PersonTests
    {
        [Test]
        public void PersonIdIncrements()
        {
            var p1 = new Person("John");
            var p2 = new Person("Pesho");

            Assert.That(p1.Id, Is.LessThan(p2.Id));
        }

    }
}
