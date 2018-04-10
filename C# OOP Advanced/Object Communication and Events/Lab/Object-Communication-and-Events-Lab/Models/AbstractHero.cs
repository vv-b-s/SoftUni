using System;
public abstract class AbstractHero : IAttacker
{
    private const string TARGET_NULL_MESSAGE = "Target is null.";
    private const string NO_TARGET_MESSAGE = "{0} has no target.";
    private const string TARGET_DEAD_MESSAGE = "{0} is dead.";
    private const string SET_TARGET_MESSAGE = "{0} targets {1}.";

    private string id;
    private int damage;
    private ITarget target;
    private IHandler logChain;

    public AbstractHero(string id, int damage, IHandler logChain)
    {
        this.id = id;
        this.damage = damage;
        this.logChain = logChain;
    }

    public IHandler LogChain => this.logChain;

    public void Attack()
    {
        if (this.target == null)
        {
            logChain.Handle(LogType.ERROR, string.Format(NO_TARGET_MESSAGE, this));
        }
        else if (this.target.IsDead)
        {
            logChain.Handle(LogType.ERROR,string.Format(TARGET_DEAD_MESSAGE, this.target));
        }
        else
        {
            this.ExecuteClassSpecificAttack(this.target, this.damage);
        }
    }

    public void SetTarget(ITarget target)
    {
        if (target == null)
        {
            logChain.Handle(LogType.ERROR,TARGET_NULL_MESSAGE);
        }
        else
        {
            this.target = target;

            logChain.Handle(LogType.EVENT,string.Format(SET_TARGET_MESSAGE, this, target));
        }
    }

    protected abstract void ExecuteClassSpecificAttack(ITarget target, int damage);

    public override string ToString()
    {
        return this.id;
    }
}
