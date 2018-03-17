using System;

public abstract class Driver:IDriver
{
    private string name;
    private double totalTime;
    private Car car;
    private bool hasFailed;
    private string failReason;

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
    }

    public string Name
    {
        get => this.name;
        protected set => this.name = value;
    }

    public double TotalTime
    {
        get => this.totalTime;
        set => this.totalTime = value;
    }

    public Car Car
    {
        get => this.car;
        protected set => this.car = value;
    }

    public abstract double FuelConsumptionPerKm { get; }

    public virtual double Speed => (this.car.Hp + this.car.Tyre.Degradation) / this.car.FuelAmount;

    public void DeclareFailed(string reason)
    {
        this.hasFailed = true;
        this.failReason = reason;
    }

    public override string ToString()
    {
        var output = $"{this.name} {(this.hasFailed? this.failReason:this.TotalTime.ToString("F3"))}";
        return output;
    }
}