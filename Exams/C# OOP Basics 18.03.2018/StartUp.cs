using System;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		// DO NOT rename this file's namespace or class name.
		// However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
		public static void Main(string[] args)
		{
            var dungeonMaster = new DungeonMaster();
            var input = "";
            var output = new StringBuilder();

            while(!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                try
                {

                    var arguments = input.Split();
                    var command = arguments[0];
                    arguments = arguments.Skip(1).ToArray();

                    switch (command)
                    {
                        case "JoinParty":
                            output.AppendLine(dungeonMaster.JoinParty(arguments));
                            break;

                        case "AddItemToPool":
                            output.AppendLine(dungeonMaster.AddItemToPool(arguments));
                            break;

                        case "PickUpItem":
                            output.AppendLine(dungeonMaster.PickUpItem(arguments));
                            break;

                        case "UseItem":
                            output.AppendLine(dungeonMaster.UseItem(arguments));
                            break;

                        case "UseItemOn":
                            output.AppendLine(dungeonMaster.UseItemOn(arguments));
                            break;

                        case "GiveCharacterItem":
                            output.AppendLine(dungeonMaster.GiveCharacterItem(arguments));
                            break;

                        case "GetStats":
                            output.AppendLine(dungeonMaster.GetStats());
                            break;

                        case "Attack":
                            output.AppendLine(dungeonMaster.Attack(arguments));
                            break;

                        case "Heal":
                            output.AppendLine(dungeonMaster.Heal(arguments));
                            break;

                        case "EndTurn":
                            output.AppendLine(dungeonMaster.EndTurn(null));
                            break;

                        case "IsGameOver":
                            output.AppendLine(dungeonMaster.IsGameOver().ToString());
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    output.AppendLine($"Parameter Error: {e.Message}");
                }
                catch (InvalidOperationException e)
                {
                    output.AppendLine($"Invalid Operation: {e.Message}");
                }

                if (dungeonMaster.IsGameOver())
                    break;
            }

            output.AppendLine($"Final stats:{Environment.NewLine}{dungeonMaster.GetStats()}");

            Console.Write(output.ToString());
		}
	}
}