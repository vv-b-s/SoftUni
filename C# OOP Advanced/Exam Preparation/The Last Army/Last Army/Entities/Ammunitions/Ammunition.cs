using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ammunition : IAmmunition
{
    protected Ammunition(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;

        this.WearLevel = 100 * this.Weight;
    }

    public string Name { get; protected set; }

    public double Weight { get; protected set; }

    public double WearLevel { get; protected set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}