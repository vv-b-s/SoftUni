using System;
using System.Collections.Generic;
using System.Text;

namespace Kinght_Gambit.Contracts
{
    public interface IAttackHandler
    {
        void HandleAttack(object sender, EventArgs e);
    }
}
