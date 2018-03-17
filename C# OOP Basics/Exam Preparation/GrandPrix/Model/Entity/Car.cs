using System;

public class Car:ICar
{
    private const double FuelTankMaxCap = 160;

    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp => this.hp;

    public double FuelAmount
    {
        get => this.fuelAmount;
        private set
        {
            if (value > FuelTankMaxCap)
                this.fuelAmount = FuelTankMaxCap;

            else if (value < 0)
                throw new FailedDriverException("Out of fuel");

            else this.fuelAmount = value;
        }
    }

    public Tyre Tyre
    {
        get => this.tyre;
        private set => this.tyre = value;
    }

    public void Refuel(double amount)
    {
        this.FuelAmount += amount;
    }

    public void ReduceFuel(double amount)
    {
        this.FuelAmount -= amount;
    }

    public void ChangeTyre(Tyre tyre)
    {
        this.Tyre = tyre;
    }
}