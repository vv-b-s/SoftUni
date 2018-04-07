using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    class HeroTestsMoq
    {
        [Test]
        public void HeroGainsXPWhenTargetDies()
        {
            var target = new Mock<ITarget>();
            target.Setup(t => t.Health).Returns(0);
            target.Setup(t => t.IsDead()).Returns(true);
            target.Setup(t => t.GiveExperience()).Returns(20);

            var weapon = new Mock<IWeapon>();
            weapon.Setup(w => w.DurabilityPoints).Returns(20);

            var hero = new Hero("Herobrine", weapon.Object);

            var heroInitialXp = hero.Experience;

            hero.Attack(target.Object);

            var heroCurrentXp = hero.Experience;

            Assert.That(heroCurrentXp, Is.GreaterThan(heroInitialXp));
        }
    }
}
