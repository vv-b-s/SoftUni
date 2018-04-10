using Kinght_Gambit.Contracts;
using Kinght_Gambit.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kinght_Gambit
{
    class Program
    {
        private static King king;
        private static Dictionary<string, MortalEntity> attackHandlers;

        static void Main(string[] args)
        {
            king = new King(Console.ReadLine());

            attackHandlers = Console.ReadLine()
                .Split()
                .Select(InitializeHandler<RoyalGuard>)
                .Concat(Console.ReadLine()
                .Split()
                .Select(InitializeHandler<Footman>))
                .ToDictionary(k => ((IEntity)k).Name, v => v);

            var input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Attack King")
                    king.Attack();

                else if (input.StartsWith("Kill"))
                {
                    var targetName = input.Split()[1];

                    var target = attackHandlers[targetName] as MortalEntity;
                    target.Kill();
                }
            }
        }

        private static MortalEntity InitializeHandler<TMortalEntity>(string name) where TMortalEntity:MortalEntity
        {
            var type = typeof(TMortalEntity);
            var constructor = type.GetConstructor(new Type[] { typeof(string) });

            var handlerObject = constructor.Invoke(new object[] { name });

            var handlerInstance = handlerObject as MortalEntity;

            handlerInstance.KillEvent += OnKillHandler;
            king.AttackEntity += handlerInstance.HandleAttack;

            return handlerInstance;
        }

        private static void OnKillHandler(object sender, EventArgs e)
        {
            var mortal = sender as MortalEntity;

            if (!mortal.IsAlive)
            {
                attackHandlers.Remove(mortal.Name);
                king.AttackEntity -= mortal.HandleAttack;
            }
        }
    }
}
