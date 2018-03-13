using System;
using System.Collections.Generic;
using System.Text;

public abstract class Driver: IDriver
{
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;

    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.Car = car;
        this.TotalTime = 0;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.HasFailed = false;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public double TotalTime
    {
        get => this.totalTime;
        set => this.totalTime = value;
    }

    public Car Car
    {
        get => this.car;
        private set => this.car = value;
    }

    public bool HasFailed { get; private set; }

    public string FailureReason { get; private set; }

    public double FuelConsumptionPerKm
    {
        get => this.fuelConsumptionPerKm;
        protected set => this.fuelConsumptionPerKm = value;
    }

    public virtual double Speed => (this.car.Hp + this.car.Tyre.Degradation) / this.car.FuelAmount;

    public void DeclareFailed(string failureReason)
    {
        this.FailureReason = failureReason;
        this.HasFailed = true;
    }
}