using System;
using System.Collections.Generic;
using System.Text;

namespace Food_Shortage
{
    public interface IBuyer
    {
        int BoughtFood { get; set; }

        void BuyFood();
    }
}
