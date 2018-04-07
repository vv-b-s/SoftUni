public class Hero : IHero
{
    private string name;
    private int experience;
    private IWeapon weapon;

    public Hero(string name, IWeapon weapon)
    {
        this.name = name;
        this.experience = 0;
        this.weapon = weapon;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public int Experience
    {
        get => this.experience;
        private set => this.experience = value;
    }

    public IWeapon Weapon
    {
        get => this.weapon;
        private set => this.weapon = value;
    }

    public void Attack(ITarget target)
    {
        this.weapon.Attack(target);

        if (target.IsDead())
        {
            this.experience += target.GiveExperience();
        }
    }
}
