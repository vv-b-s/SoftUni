using System;
public class Warrior : AbstractHero
{
    private const string ATTACK_MESSAGE = "{0} damages {1} for {2}";

    public Warrior(string id, int damage, IHandler logChain) : base(id, damage, logChain)
    {
    }

    protected override void ExecuteClassSpecificAttack(ITarget target, int damage)
    {
        this.LogChain.Handle(LogType.ATTACK,string.Format(ATTACK_MESSAGE, this, target, damage));
    }
}
