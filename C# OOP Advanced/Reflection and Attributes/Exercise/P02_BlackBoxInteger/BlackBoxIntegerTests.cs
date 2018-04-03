namespace P02_BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var bbInstance = typeof(BlackBoxInteger).GetConstructor(System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Instance, null, new Type[0], null).Invoke(new object[0]);

            var input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                var data = input.Split('_');

                var method = bbInstance.GetType().GetMethod(data[0],System.Reflection.BindingFlags.Instance|System.Reflection.BindingFlags.NonPublic);
                var argument = int.Parse(data[1]);

                method.Invoke(bbInstance, new object[] { argument });

                var lastestResult = bbInstance.GetType()
                .GetField("innerValue", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .GetValue(bbInstance);


                Console.WriteLine(lastestResult);
            }            
        }
    }
}
