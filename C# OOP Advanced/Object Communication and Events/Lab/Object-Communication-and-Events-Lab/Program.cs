using System;

namespace Object_Communication_and_Events_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var logChain = GenerateLogChain();

            IAttackGroup group = new Group();

            group.AddMember(new Warrior("Torsten", 10, logChain));
            group.AddMember(new Warrior("Rolo", 15, logChain));

            ITarget dragon = new Dragon("Trnasylvanian White", 200, 25, logChain);

            IExecutor executor = new CommandExecutor();

            ICommand groupTarget = new GroupTargetCommand(group, dragon);
            ICommand groupAttack = new GroupAttackCommand(group);

            executor.ExecuteCommand(groupTarget);
            executor.ExecuteCommand(groupAttack);
        }

        public static IHandler GenerateLogChain()
        {
            var combatLogger = new CombatLogger();
            var eventLogger = new EventLogger();

            combatLogger.SetSuccessor(eventLogger);

            return combatLogger;
        }
    }
}
