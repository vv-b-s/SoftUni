using NUnit.Framework;
using Skeleton.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTests
    {
        private const int DefaultTargetHealth = 2;
        private const int DefaultTargetExperienceReturn = 1;

        private const int FakeAxeAttackPoints = 10;
        private const int FakeAxeDurabilityPoints = 10;
        private const int FakeAxeDamage = 1;

        private IHero hero;
        private ITarget target;
        private IWeapon weapon;

        [SetUp]
        public void Init()
        {
            this.target = new FakeTarget(DefaultTargetHealth, DefaultTargetExperienceReturn);
            this.weapon = new FakeAxe(FakeAxeAttackPoints, FakeAxeDurabilityPoints, FakeAxeDamage);


            this.hero = new Hero("Herobrine", this.weapon);
        }

        [Test]
        public void HeroGainsXPWhenTargetDies()
        {
            var previousHeroXp = this.hero.Experience;

            ((FakeTarget)target).KillTarget();
            this.hero.Attack(this.target);

            var heroXpAfterAttack = this.hero.Experience;

            Assert.That(heroXpAfterAttack, Is.GreaterThan(previousHeroXp), "Hero does not gain XP after killing target");
        }

        [Test]
        public void HeroDoesNotGainXPWhenTargetIsAlive()
        {
            var previousHeroXp = this.hero.Experience;

            this.hero.Attack(this.target);

            var heroXpAfterAttack = this.hero.Experience;

            Assert.That(heroXpAfterAttack, Is.EqualTo(previousHeroXp), "Hero gains XP when target is alive");
        }
    }
}
