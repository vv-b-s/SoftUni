using NUnit.Framework;
using Skeleton.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int InitialAxeValues = 100;
        private const int InitialDummyValues = 2;

        private const int InitalWeaponDamage = 1;

        private IWeapon axe;
        private ITarget dummy;

        [SetUp]
        public void Init()
        {
            this.axe = new FakeAxe(InitialAxeValues, InitialAxeValues, InitalWeaponDamage);
            this.dummy = new Dummy(InitialDummyValues, InitialDummyValues);
        }


        [Test]
        public void DummyLosesHealthWhenAttacked()
        {
            var initialDummyHealth = this.dummy.Health;

            axe.Attack(dummy);

            var currentDummyHealth = this.dummy.Health;

            Assert.That(currentDummyHealth, Is.LessThan(initialDummyHealth));
        }

        [Test]
        public void DeadDummyShouldThrowAnExceptionWhenDead()
        {
            KillDummy(this.dummy, this.axe);
            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyGivesXP()
        {
            KillDummy(this.dummy, this.axe);

            Assert.That(dummy.GiveExperience, Throws.Nothing);
        }

        [Test]
        public void AliveDummyDoesntGiveXP()
        {
            Assert.That(this.dummy.GiveExperience, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }


        private void KillDummy(ITarget dummy, IWeapon axe)
        {
            try
            {
                while (this.dummy.Health > 0)
                    this.axe.Attack(this.dummy);
            }
            catch (InvalidCastException) { }
        }
    }
}
