public interface IAttacker
{
    void Attack();

    void SetTarget(ITarget target);

    IHandler LogChain { get; }
}
