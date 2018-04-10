using System;
using System.Collections.Generic;
using System.Text;

namespace Kinght_Gambit.Contracts
{
    public delegate void AttackHandler(object sender, EventArgs args);
    public interface IAttackable
    {
        event AttackHandler AttackEntity;

        void Attack();
    }
}
