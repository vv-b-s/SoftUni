using System;
using System.Collections.Generic;
using System.Text;

public class Car : ICar
{
    private const double FuelTankMaxCap = 160;

    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount,Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp
    {
        get => this.hp;
        protected set => this.hp = value;
    }

    public double FuelAmount
    {
        get => this.fuelAmount;
        protected set
        {
            if (value < 0)
                throw new ArgumentException("Out of fuel");

            else this.fuelAmount = value > FuelTankMaxCap ? FuelTankMaxCap : value;
        }
    }

    public Tyre Tyre
    {
        get => this.tyre;
        protected set => this.tyre = value;
    }

    public void Refuel(double amount) => this.FuelAmount += amount;

    public void DecreaseFuel(int trackLength, double amount) => this.FuelAmount -= amount * trackLength;

    public void ChangeTyres(Tyre tyre) => this.Tyre = tyre;
}