using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private int lapsNumber;
    private int trackLength;
    private int currentLap;
    private string weather;

    private Dictionary<string, Driver> registeredDrivers;
    private Dictionary<string, Driver> failedDrivers;

    public RaceTower()
    {
        this.registeredDrivers = new Dictionary<string, Driver>();
        this.failedDrivers = new Dictionary<string, Driver>();

        weather = "Sunny";
    }

    public Driver Winner => this.registeredDrivers.Values.OrderBy(d => d.TotalTime).First();
    public int CurrentLap => this.currentLap;
    public int LapsNumber => this.lapsNumber;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.lapsNumber = lapsNumber;
        this.trackLength = trackLength;
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var driver = DriverFactory.CreateDriver(commandArgs);
            this.registeredDrivers[driver.Name] = driver;
        }
        catch (Exception) { }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reason = commandArgs[0];
        var driver = this.registeredDrivers[commandArgs[1]];

        var arguments = commandArgs.Skip(2).ToList();

        if (reason == "ChangeTyres")
            driver.Car.ChangeTyre(TyreFactory.CreateTyre(arguments));

        else if (reason == "Refuel")
            driver.Car.Refuel(double.Parse(arguments[0]));

        driver.TotalTime += 20;
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var numberOfLapsToMake = int.Parse(commandArgs[0]);
        var numberOfPossibleLaps = this.lapsNumber - this.currentLap;

        var overtakeMessages = new List<string>();

        if (numberOfLapsToMake <= numberOfPossibleLaps)
        {
            while (numberOfLapsToMake-- > 0)
            {
                this.currentLap++;
                foreach (var driver in registeredDrivers.Values)
                {
                    try
                    {
                        driver.TotalTime += 60 / (this.trackLength / driver.Speed);
                        driver.Car.ReduceFuel(this.trackLength * driver.FuelConsumptionPerKm);
                        driver.Car.Tyre.DegradateTyre();
                    }
                    catch (FailedDriverException e)
                    {
                        driver.DeclareFailed(e.Message);
                        this.failedDrivers[driver.Name] = driver;
                    }
                }

                this.registeredDrivers = this.registeredDrivers
                    .Except(failedDrivers)
                    .ToDictionary(k => k.Key, v => v.Value);

                this.TryOvertaking(overtakeMessages);
            }

            return string.Join(Environment.NewLine, overtakeMessages);
        }
        else return $"There is no time! On lap {this.currentLap}.";
    }

    public string GetLeaderboard()
    {
        var lapData = new StringBuilder($"Lap {this.currentLap}/{this.lapsNumber}" + Environment.NewLine);
        var driversList = this.registeredDrivers.Values
            .OrderBy(d => d.TotalTime)
            .Concat(failedDrivers.Values
            .Reverse()).ToList();

        lapData.Append(string.Join(Environment.NewLine, driversList
            .Select(d => $"{driversList.IndexOf(d) + 1} {d}")));

        return lapData.ToString();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.weather = commandArgs[0];
    }

    private void TryOvertaking(List<string> messages)
    {
        var driverQueue = new Queue<Driver>(this.registeredDrivers.Values.OrderByDescending(d => d.TotalTime));

        while (driverQueue.Count > 1)
        {
            var driverBehind = driverQueue.Dequeue();
            var driverInFront = driverQueue.Peek();

            var timeDiff = Math.Abs(driverBehind.TotalTime - driverInFront.TotalTime);
            var alteringTime = 0;
            var driverFailed = false;

            if (driverBehind is AggressiveDriver && driverBehind.Car.Tyre is UltrasoftTyre)
            {
                alteringTime = 3;

                if (weather == "Foggy")
                    driverFailed = true;
            }

            else if (driverBehind is EnduranceDriver && driverBehind.Car.Tyre is HardTyre)
            {
                alteringTime = 3;

                if (weather == "Rainy")
                    driverFailed = true;
            }

            else alteringTime = 2;

            if (timeDiff <= alteringTime)
            {
                if (driverFailed)
                {
                    driverBehind.DeclareFailed("Crashed");
                    failedDrivers[driverBehind.Name] = driverBehind;
                    this.registeredDrivers.Remove(driverBehind.Name);
                }

                else
                {
                    driverInFront.TotalTime += alteringTime;
                    driverBehind.TotalTime -= alteringTime;

                    messages.Add($"{driverBehind.Name} has overtaken {driverInFront.Name} on lap {this.currentLap}.");

                    //Pop the stack again so the driver in front cannot overtake any other driver for this lap
                    driverQueue.Dequeue();
                }
            }
        }
    }
}