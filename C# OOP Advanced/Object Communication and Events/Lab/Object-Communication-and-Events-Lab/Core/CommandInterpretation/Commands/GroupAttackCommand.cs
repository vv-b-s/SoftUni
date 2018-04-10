﻿using System;
using System.Collections.Generic;
using System.Text;

public class GroupAttackCommand : ICommand
{
    private IAttackGroup group;

    public GroupAttackCommand(IAttackGroup group)
    {
        this.group = group;
    }

    public void Execute()
    {
        this.group.GroupAttack();
    }
}