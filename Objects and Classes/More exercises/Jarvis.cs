using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using static System.Console;

public class Robot
{
    public Head head{ get; set; }
    public List<Arm> arms { get; set; }
    public Torso torso { get; set; }
    public List<Leg> legs { get; }

    public long Energy =>
        head.EnergyConsumption  +
        arms.Sum(a=>a.EnergyConsumption)  +
        torso.EnergyConsumption +
        legs.Sum(l=> l.EnergyConsumption);


    #region Part classes
    interface IConsumption
    {
        long EnergyConsumption { set; get; }
    }

    public class Head:IConsumption
    {
        public long EnergyConsumption { get; set; }
        public long IQ { set; get; }
        public string SkinMaterial { set; get; }

        public string Stats
        {
            get
            {
                var sB = new StringBuilder();
                sB.AppendLine($"#Head:\n" +
                    $"###Energy consumption: {EnergyConsumption}\n" +
                    $"###IQ: {IQ}\n" +
                    $"###Skin material: {SkinMaterial}");
                return sB.ToString();
            }
        }

        public Head(string energyConsumption, string iq, string skinMaterial)
        {
            EnergyConsumption = long.Parse(energyConsumption);
            IQ = long.Parse(iq);
            SkinMaterial = skinMaterial;
        }
    }

    public class Arm : IConsumption
    {
        public long EnergyConsumption { set; get; }
        public long ReachDistance { set; get; }
        public long FingersCount { set; get; }

        public string Stats
        {
            get
            {
                var sB = new StringBuilder();
                sB.AppendLine($"#Arm:\n" +
                    $"###Energy consumption: {EnergyConsumption}\n" +
                    $"###Reach: {ReachDistance}\n" +
                    $"###Fingers: {FingersCount}");
                return sB.ToString();
            }
        }

        public Arm(string energyCon, string reachDistance, string fingersCount)
        {
            EnergyConsumption = long.Parse(energyCon);
            ReachDistance = long.Parse(reachDistance);
            FingersCount = long.Parse(fingersCount);
        }
    }

    public class Torso : IConsumption
    {
        public long EnergyConsumption { set; get; }
        public double ProccessorSize { set; get; }
        public string HousingMaterial { set; get; }

        public string Stats
        {
            get
            {
                var sB = new StringBuilder();
                sB.AppendLine($"#Torso:\n" +
                    $"###Energy consumption: {EnergyConsumption}\n" +
                    $"###Processor size: {ProccessorSize:f1}\n" +
                    $"###Corpus material: {HousingMaterial}");
                return sB.ToString();
            }
        }

        public Torso(string energyCons, string procSize, string housingMat)
        {
            EnergyConsumption = long.Parse(energyCons);
            ProccessorSize = double.Parse(procSize);
            HousingMaterial = housingMat;
        }
    }

    public class Leg : IConsumption
    {
        public long EnergyConsumption { set; get; }
        public long Strength { get; set; }
        public long Speed { get; set; }

        public string Stats
        {
            get
            {
                var sB = new StringBuilder();
                sB.AppendLine($"#Leg:\n" +
                    $"###Energy consumption: {EnergyConsumption}\n" +
                    $"###Strength: {Strength}\n" +
                    $"###Speed: {Speed}");
                return sB.ToString();
            }
        }

        public Leg(string energyCons, string str, string speed)
        {
            EnergyConsumption = long.Parse(energyCons);
            Strength = long.Parse(str);
            Speed = long.Parse(speed);
        }
    }
    #endregion

    public Robot(Head head, Arm arm1,Arm arm2, Torso torso,Leg leg1, Leg leg2)
    {
        this.head = head;
        this.arms = new List<Arm> { arm1, arm2 };
        this.torso = torso;
        this.legs = new List<Leg> { leg1, leg2 };
    }

    public string ListStats() => $"{head.Stats}{torso.Stats}{arms[0].Stats}{arms[1].Stats}{legs[0].Stats}{legs[1].Stats}";
}

class Program
{
    static void Main()
    {
        long maxEnergy = long.Parse(ReadLine());

        var headList = new List<Robot.Head>();
        var armsList = new List<Robot.Arm>();
        var torsoList = new List<Robot.Torso>();
        var legsList = new List<Robot.Leg>();

        string input;
        while ((input = ReadLine()) != "Assemble!")
        {
            string[] temp = input.Split();
            string component = temp[0];
            string energy = temp[1];
            string prop1 = temp[2];
            string prop2 = temp[3];

            switch (component)
            {
                case "Head":
                    headList.Add(new Robot.Head(energy, prop1, prop2));
                    break;
                case "Arm":
                    armsList.Add(new Robot.Arm(energy, prop1, prop2));
                    break;
                case "Torso":
                    torsoList.Add(new Robot.Torso(energy, prop1, prop2));
                    break;
                case "Leg":
                    legsList.Add(new Robot.Leg(energy, prop1, prop2));
                    break;
            }
        }

        if (headList.Count == 0 || armsList.Count < 2|| torsoList.Count == 0|| legsList.Count < 2)
        {
            WriteLine("We need more parts!");
            return;
        }

        headList = headList.OrderBy(h => h.EnergyConsumption).ToList();
        armsList = armsList.OrderBy(a => a.EnergyConsumption).ToList();
        torsoList = torsoList.OrderBy(t => t.EnergyConsumption).ToList();
        legsList = legsList.OrderBy(l => l.EnergyConsumption).ToList();

        var Jarvis = new Robot(headList[0],armsList[0],armsList[1],torsoList[0],legsList[0],legsList[1]);
        Write(Jarvis.Energy <= maxEnergy ?
            $"Jarvis:\n{Jarvis.ListStats()}" :
           "We need more power!\n");
    }
}