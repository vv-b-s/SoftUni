using System;

namespace Event_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var handler = new Handler();
            var dispatcher = new Dispatcher();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            var input = "";
            while((input = Console.ReadLine())!="End")
            {
                dispatcher.Name = input;
            }
        }
    }
}
