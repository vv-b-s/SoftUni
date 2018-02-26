using System;
using System.Collections.Generic;
using System.Text;

public class Seat : ICar
{
    private string model;
    private string color;

    public Seat(string model, string color)
    {
        Model = model;
        Color = color;
    }

    public string Model { get => model; set => model = value; }
    public string Color { get => color; set => color = value; }
    protected virtual string CarDetails => $"{Color} {this.GetType().Name} {model}";

    public string Start() => "Engine start";

    public string Stop() => "Breaaak!";

    public override string ToString() =>
        $"{CarDetails}\n" +
        $"{Start()}\n" +
        $"{Stop()}";
}