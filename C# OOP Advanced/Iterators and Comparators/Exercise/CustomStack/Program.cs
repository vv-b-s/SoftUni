using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CustomStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            var stack = new Stack<string>();

            while((input=Console.ReadLine())!="END")
            {
                try
                {
                    var data = input.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    var command = data[0];
                    switch (command)
                    {
                        case "Push":
                            var elements = data.Skip(1);
                            foreach (var element in elements)
                                stack.Push(element);
                            break;

                        case "Pop":
                            stack.Pop();
                            break;
                    }
                }
                catch (InvalidOperationException e)
                {

                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine,stack));
            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }
    }
}
