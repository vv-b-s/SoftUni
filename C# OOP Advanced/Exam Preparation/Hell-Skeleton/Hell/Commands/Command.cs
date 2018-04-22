using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Command : ICommand
{
    private IList<string> arguments;

    protected Command(IList<string> arguments, IManager manager)
    {
        this.arguments = arguments;
        this.Manager = manager;
    }

    public IReadOnlyList<string> Arguments => this.arguments.ToList().AsReadOnly();
    public IManager Manager { get; protected set; }


    public abstract string Execute();
}
