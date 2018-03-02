using Military_elite.AbstractClasses;
using System;
using System.Collections.Generic;

namespace Military_elite
{
    class Program
    {
        static void Main(string[] args)
        {
            var soldiers = new List<Soldier>();

            var input = "";
            while((input = Console.ReadLine())!="End")
            {
                try
                {
                    var soldier = SoldierFactory.CreateSoldier(input.Split(), soldiers);
                    
                    if(soldier!=null)
                        soldiers.Add(soldier);
                }
                catch (ArgumentException ex) {  }
            }

            Console.WriteLine(string.Join(Environment.NewLine,soldiers));
        }
    }
}
