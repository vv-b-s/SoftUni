using System;
using System.Collections.Generic;
using System.Text;

public class UltrasoftTyre : Tyre
{
    private double grip;

    public UltrasoftTyre(double hardness, double grip) : base(hardness)
    {
        this.Grip = grip;
        this.Name = "Ultrasoft";
    }

    public double Grip
    {
        get => this.grip;
        private set => this.grip = value;
    }

    protected override int BlowUpLimit => 30;

    public override void ReduceDegradation()
    {
        this.Degradation -= this.Hardness + this.Grip;
    }
}
