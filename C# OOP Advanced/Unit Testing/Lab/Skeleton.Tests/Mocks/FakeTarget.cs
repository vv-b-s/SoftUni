using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests.Mocks
{
    class FakeTarget : ITarget
    {
        private int returnExperience;

        public FakeTarget(int helath, int returnExperience)
        {
            this.Health = helath;
            this.returnExperience = returnExperience;
        }

        public int Health { get; private set; }

        public int GiveExperience()
        {
            if(this.IsDead())
                return returnExperience;

            else return 0;
        }

        public bool IsDead() => this.Health <= 0;

        public void TakeAttack(int attackPoints)
        {
            this.Health -= attackPoints;
        }

        public void KillTarget() => this.Health = 0;
    }
}
