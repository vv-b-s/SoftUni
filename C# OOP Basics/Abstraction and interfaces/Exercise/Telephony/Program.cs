using System;
using System.Collections.Generic;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneNumbersRaw = Console.ReadLine().Split();
            var websitesRaw = Console.ReadLine().Split();

            foreach(var phoneNumber in phoneNumbersRaw)
            {
                try
                {
                    var phone = new SmartPhone(phoneNumber, true);
                    Console.WriteLine(phone.Call());
                }
                catch (ArgumentException e) { Console.WriteLine(e.Message); }
            }

            foreach(var url in websitesRaw)
            {
                try
                {
                    var phone = new SmartPhone(url, false);
                    Console.WriteLine(phone.VisitURL());
                }
                catch (ArgumentException e) { Console.WriteLine(e.Message); }
            }
        }
    }
}
