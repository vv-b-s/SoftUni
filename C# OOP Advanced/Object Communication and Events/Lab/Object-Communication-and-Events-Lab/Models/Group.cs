using System;
using System.Collections.Generic;
using System.Text;

public class Group : IAttackGroup
{
    private List<IAttacker> members;

    public Group()
    {
        this.members = new List<IAttacker>();
    }

    public void AddMember(IAttacker attacker)
    {
        this.members.Add(attacker);
    }

    public void GroupAttack()
    {
        foreach (var member in this.members)
            member.Attack();
    }

    public void GroupTarget(ITarget target)
    {
        foreach (var member in this.members)
            member.SetTarget(target);
    }
}