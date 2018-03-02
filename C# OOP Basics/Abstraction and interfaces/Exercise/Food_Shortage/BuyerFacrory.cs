using System;
using System.Collections.Generic;
using System.Text;

namespace Food_Shortage
{
    public static class BuyerFacrory
    {
        public static IBuyer Manufacture(string[] data)
        {
            switch(data.Length)
            {
                case 3: return new Rebel(name: data[0], age: int.Parse(data[1]), group: data[2]);
                case 4: return new Citizen(name: data[0], age: int.Parse(data[1]), id: data[2], birthdate: data[3]);
                default: return null;
            }
        }
    }
}
