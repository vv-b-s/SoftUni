using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameController
{
    private MissionController missionControllerField;

    private IWareHouse wareHouse;
    private IAmmunitionFactory ammunitionFactory;
    private ISoldierFactory soldierFactory;
    private IArmy army;
    private IMissionFactory missionFactory;
    private IWriter writer;

    public GameController(IWareHouse wareHouse, IAmmunitionFactory ammunitionFactory, ISoldierFactory soldierFactory, IArmy army, IMissionFactory missionFactory, IWriter writer)
    {
        this.wareHouse = wareHouse;
        this.ammunitionFactory = ammunitionFactory;
        this.soldierFactory = soldierFactory;
        this.army = army;
        this.missionFactory = missionFactory;

        this.writer = writer;

        this.missionControllerField = new MissionController(army, this.wareHouse);
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        if (data[0].Equals("Soldier"))
        {
            string type = string.Empty;
            string name = string.Empty;
            int age = 0;
            double experience = 0;
            double endurance = 0d;

            if (data.Length == 3)
            {
                type = data[1];
                name = data[2];
            }
            else
            {
                type = data[1];
                name = data[2];
                age = int.Parse(data[3]);
                experience = double.Parse(data[4]);
                endurance = double.Parse(data[5]);
            }

            switch (type)
            {
                case "Ranker":
                case "Corporal":
                case "SpecialForce":
                    try
                    {
                        var soldier = soldierFactory.CreateSoldier(type, name, age, experience, endurance);
                        army.AddSoldier(soldier);
                    }
                    catch (InvalidOperationException e)
                    {
                        writer.WriteLine(e.Message);
                    }
                    break;

                case "Regenerate":
                    this.army.RegenerateTeam(name);
                    break;
            }

        }
        else if (data[0].Equals("WareHouse"))
        {
            string name = data[1];
            int number = int.Parse(data[2]);

            while (number-- > 0)
                wareHouse.AddAmmunitions(ammunitionFactory.CreateAmmunition(name));
        }
        else if (data[0].Equals("Mission"))
        {
            var missionDifficulty = data[1];
            var scoresToComplete = double.Parse(data[2]);

            var missionInstance = missionFactory.CreateMission(missionDifficulty, scoresToComplete);

            writer.WriteLine(this.missionControllerField.PerformMission(missionInstance).TrimEnd());
        }
    }

    public string RequestResult()
    {
        this.missionControllerField.FailMissionsOnHold();

        var sB = new StringBuilder();
        sB.AppendLine("Results:");
        sB.AppendLine($"Successful missions - {missionControllerField.SuccessMissionCounter}");
        sB.AppendLine($"Failed missions - {missionControllerField.FailedMissionCounter}");

        var orderedSoldiers = this.army.Soldiers.OrderByDescending(s => s.OverallSkill);

        sB.Append($"Soldiers:{Environment.NewLine}{string.Join(Environment.NewLine, orderedSoldiers)}");

        return sB.ToString();
    }
}