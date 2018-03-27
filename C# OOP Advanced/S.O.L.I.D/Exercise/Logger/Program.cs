using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfAppenders = int.Parse(Console.ReadLine());
            var controller = new Controller();

            while (numberOfAppenders-- > 0)
                controller.AddAppender(Console.ReadLine());

            var input = "";
            while ((input = Console.ReadLine()) != "END")
                controller.WriteLog(input);

            foreach(var appender in controller.Appenders)
            {
                Console.WriteLine(appender);
                Console.WriteLine();
            }
        }
    }
}
