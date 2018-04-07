using System;
using System.Linq;

namespace Iterator_Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            ListIterator<string> list = null;

            while((input=Console.ReadLine())!="END")
            {
                var data = input.Split();
                var command = data[0];

                try
                {
                    switch (command)
                    {
                        case "Create":
                            var items = data.Skip(1).ToArray();
                            list = new ListIterator<string>(items);
                            break;

                        case "HasNext":
                            Console.WriteLine(list.HasNext());
                            break;

                        case "Move":
                            Console.WriteLine(list.Move());
                            break;

                        case "Print":
                            Console.WriteLine(list.Print());
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
