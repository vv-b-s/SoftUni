using System;
using System.Collections.Generic;
using System.Text;

public class Tesla : Seat, IElectricCar
{
    private int battery;

    public Tesla(string model, string color, int battery):base(model,color)
    {
        Battery = battery;
    }

    public int Battery { get => battery; set => battery = value; }
    protected override string CarDetails => base.CarDetails + $" with {battery} Batteries";
}
