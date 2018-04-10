using System;
using System.Collections.Generic;
using System.Text;

public class GroupTargetCommand : ICommand
{
    private IAttackGroup group;
    private ITarget target;

    public GroupTargetCommand(IAttackGroup group, ITarget target)
    {
        this.group = group;
        this.target = target;
    }

    public void Execute()
    {
        this.group.GroupTarget(this.target);
    }
}