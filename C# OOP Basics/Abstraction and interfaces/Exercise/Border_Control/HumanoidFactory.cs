using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public static class HumanoidFactory
    {
        /// <summary>
        /// Depending on the input length will create either robot or citizen
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static IHumanoid MakeHumanoid(string[] input)
        {
            if (input.Length == 2)
                return new Robot(alias: input[0], id: input[1]);
            else if (input.Length == 3)
                return new Citizen(alias: input[0], age: int.Parse(input[1]), id: input[2]);

            else return null;
        }
    }
}
