public class MachineGun:Ammunition
{
    private const double DefaultWeight = 10.6;

    public MachineGun(string name)
        : base(name, DefaultWeight)
    {
    }
}