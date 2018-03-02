using System;
using System.Collections.Generic;
using System.Text;

namespace Food_Shortage
{
    class Rebel : Human, IBuyer
    {

        public Rebel(string name, int age, string group):base(name, age)
        {
            Group = group;
        }

        public int BoughtFood { get; set; }

        public string Group { get; set; }

        public void BuyFood() => BoughtFood += 5;
    }
}
