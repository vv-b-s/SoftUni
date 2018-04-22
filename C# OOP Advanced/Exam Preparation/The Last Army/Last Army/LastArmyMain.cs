using System;
using System.Text;

public class LastArmyMain
{
    static void Main()
    {
        var wareHouse = new WareHouse();
        var ammunitionFactory = new AmmunitionFactory();
        var soldiersFactory = new SoldierFactory();
        var missionFactory = new MissionFactory();
        var reader = new ConsoleReader();
        var writer = new ConsoleWriter();

        var army = new Army(wareHouse);

        var gameController = new GameController(wareHouse, ammunitionFactory, soldiersFactory, army, missionFactory, writer);

        var engine = new Engine(gameController, reader, writer);

        engine.Run();
    }
}