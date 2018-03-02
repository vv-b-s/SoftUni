using System;
using System.Collections.Generic;
using System.Text;

namespace Food_Shortage
{
    public class Citizen : Human, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate):base(name, age)
        {
            Id = id;
            Birthdate = birthdate;
        }

        public int BoughtFood { get; set; }

        public string Id { get; set; }

        public string Birthdate { get; set; }

        public void BuyFood() => BoughtFood += 10;
    }
}
