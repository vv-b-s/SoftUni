using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class StartUp
{
    static void Main(string[] args)
    {
        var input = "";
        var interpreter = new Interpreter();

        while ((input = Console.ReadLine())!= "Paw Paw Pawah")
        {
            var data = Regex.Split(input, @" \| ");
            var command = data[0];

            switch(command)
            {
                case "RegisterCleansingCenter":
                    interpreter.RegisterCenter(typeof(CleansingCenter), data[1]);
                    break;

                case "RegisterAdoptionCenter":
                    interpreter.RegisterCenter(typeof(AdoptionCenter), data[1]);
                    break;

                case "RegisterCastrationCenter":
                    interpreter.RegisterCenter(typeof(CastrationCenter), data[1]);
                    break;

                case "RegisterDog":
                    interpreter.RegisterAnimal(typeof(Dog), data.Skip(1).ToArray());
                    break;

                case "RegisterCat":
                    interpreter.RegisterAnimal(typeof(Cat), data.Skip(1).ToArray());
                    break;

                case "SendForCleansing":
                    interpreter.SendForCleansing(data[1], data[2]);
                    break;

                case "Cleanse":
                    interpreter.Cleanse(data[1]);
                    break;

                case "Adopt":
                    interpreter.Adopt(data[1]);
                    break;

                case "Castrate":
                    interpreter.Castrate(data[1]);
                    break;

                case "SendForCastration":
                    interpreter.SendForCastration(data[1], data[2]);
                    break;

                case "CastrationStatistics":
                    Console.WriteLine(interpreter.CastrationStatistics());
                    break;
            }
        }

        Console.WriteLine(interpreter.PawPawPawah());
    }
}
