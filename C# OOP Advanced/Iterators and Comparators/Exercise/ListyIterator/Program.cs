using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            ListyIterator<string> list = null;

            while((input = Console.ReadLine())!="END")
            {
                var data = input.Split();
                var command = data[0];

                try
                {
                    switch (command)
                    {
                        case "Create":
                            var items = data.Skip(1).ToArray();
                            list = new ListyIterator<string>(items);
                            break;

                        case "Move":
                            Console.WriteLine(list.Move());
                            break;

                        case "Print":
                            Console.WriteLine(list.Print());
                            break;

                        case "HasNext":
                            Console.WriteLine(list.HasNext);
                            break;

                        case "PrintAll":
                            Console.WriteLine(string.Join(" ",list));
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
