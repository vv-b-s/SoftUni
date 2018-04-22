using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private ICommandInterpreter commandInterpreter;
    private IReaderWriter readerWriter;

    public Engine(ICommandInterpreter commandInterpreter, IReaderWriter readerWriter)
    {
        this.commandInterpreter = commandInterpreter;
        this.readerWriter = readerWriter;
    }

    public void Run()
    {
        var input = "";
        var sb = new StringBuilder();

        while ((input=readerWriter.ReadLine().Trim())!="Shutdown")
        {
            var commandResult = this.commandInterpreter.ProcessCommand(input.Split());

            sb.AppendLine(commandResult);    
        }

        var lastCommand = this.commandInterpreter.ProcessCommand(input.Split());
        sb.Append(lastCommand);

        readerWriter.WriteLine(sb.ToString());
    }
}
