using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private GameController gameController;
    private IReader reader;
    private IWriter writer;

    public Engine(GameController gameController, IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;

        this.gameController = gameController;
    }

    public void Run()
    {
        var input = "";
        while ((input = reader.ReadLine()) != "Enough! Pull back!")
            gameController.GiveInputToGameController(input);

        var result = gameController.RequestResult();
        writer.WriteLine(result.ToString());
    }


}
