using System;

public class UltrasoftTyre : Tyre
{
    private double grip;

    public UltrasoftTyre(double hardness, double grip) : base(hardness)
    {
        this.Grip = grip;
    }

    public double Grip
    {
        get => this.grip;
        private set => this.grip = value;
    }

    public override string Name => "Ultrasoft";

    protected override double MinimumDegradation => 30;

    public override void DegradateTyre()
    {
        this.Degradation -= this.Hardness + this.Grip;
    }
}