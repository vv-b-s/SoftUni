using System;

namespace Linked_List_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>();

            var numberOfCommands = int.Parse(Console.ReadLine());
            while (numberOfCommands-- > 0)
            {
                var data = Console.ReadLine().Split();
                var command = data[0];
                var number = int.Parse(data[1]);

                switch (command)
                {
                    case "Add":
                        list.Add(number);
                        break;

                    case "Remove":
                        list.Remove(number);
                        break;
                }
            }

            Console.WriteLine(list.Count);
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
