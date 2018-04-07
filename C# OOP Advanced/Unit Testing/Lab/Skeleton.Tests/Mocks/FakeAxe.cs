using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests.Mocks
{
    class FakeAxe : IWeapon
    {

        public FakeAxe(int attackPoints, int durabilityPoints, int damage)
        {
            this.AttackPoints = attackPoints;
            this.DurabilityPoints = durabilityPoints;
            this.Damage = damage;
        }

        public int AttackPoints { get; }

        public int DurabilityPoints { get; }

        public int Damage { get; }

        public void Attack(ITarget target)
        {
            target.TakeAttack(Damage);
        }
    }
}
