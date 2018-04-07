using NUnit.Framework;
using Skeleton.Tests.Mocks;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int InitialAxeValues = 2;
        private const int InitialDummyValues = 100;

        private  IWeapon axe;
        private ITarget dummy;

        [SetUp]
        public void Init()
        {
            this.axe = new Axe(InitialAxeValues, InitialAxeValues);
            this.dummy = new FakeTarget(InitialDummyValues, InitialDummyValues);
        }

        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            var durability = axe.DurabilityPoints;

            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.LessThan(durability), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void AxeAttackingWhenBroken()
        {
            while (axe.DurabilityPoints > 0)
                axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
