using System;
using System.Collections.Generic;
using System.Linq;

namespace Border_Control
{
    class Program
    {
        static void Main(string[] args)
        {
            var humanoids = new List<IHumanoid>();

            var input = "";
            while((input = Console.ReadLine())!="End")
            {
                var data = input.Split();
                humanoids.Add(HumanoidFactory.MakeHumanoid(data));
            }

            var invalidIdData = Console.ReadLine();

            Console.WriteLine(string.Join("\n", humanoids.Where(h => h.Id.EndsWith(invalidIdData)).Select(h=>h.Id)));
        }
    }
}
