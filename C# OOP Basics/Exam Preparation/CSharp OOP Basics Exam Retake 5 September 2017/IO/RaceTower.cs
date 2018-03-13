using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{

    private Dictionary<string, Driver> registeredDrivers;
    private Dictionary<string, Driver> failedDrivers;

    private int lapsNumber;
    private int trackLength;
    private int currentLap;
    private string weather;

    public RaceTower()
    {
        registeredDrivers = new Dictionary<string, Driver>();
        failedDrivers = new Dictionary<string, Driver>();

        this.weather = "Sunny";
    }

    public int LapsNumber => this.lapsNumber;

    public int TrackLength => this.trackLength;

    public int CurrentLap => this.currentLap;

    public string Weather => this.weather;

    /// <summary>
    /// Get the driver with smallest total time which hasn't failed
    /// </summary>
    public Driver Winner => registeredDrivers.OrderBy(d => d.Value.TotalTime).First().Value;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.lapsNumber = lapsNumber;
        this.trackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            if (commandArgs.Count > 7)
                throw new Exception();

            var argsAsQueue = new Queue<string>(commandArgs);

            var driver = DriverFactory.CreateDriver(argsAsQueue);

            registeredDrivers[driver.Name] = driver;
        }
        catch (Exception)
        {

        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {

        var reasonToBox = commandArgs[0];
        var driverName = commandArgs[1];

        var driver = registeredDrivers[driverName];

        if (reasonToBox == "Refuel")
        {
            var fuel = double.Parse(commandArgs[2]);
            driver.Car.Refuel(fuel);
        }

        else if (reasonToBox == "ChangeTyres")
            driver.Car.ChangeTyres(TyreFactory.CreateTyre(new Queue<string>(commandArgs.Skip(2))));

        driver.TotalTime += 20;

    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var numberIsParsed = int.TryParse(commandArgs[0], out int numberOfLapsToComplete);
        var remaining = LapsNumber - CurrentLap;

        if (numberIsParsed && numberOfLapsToComplete <= remaining)
        {
            List<string> overtakes = new List<string>();
            while (numberOfLapsToComplete-- > 0)
            {
                currentLap++;

                var registeredDriversCopy = new Dictionary<string, Driver>(registeredDrivers);
                foreach (var driver in registeredDriversCopy.Values)
                {
                    if (!driver.HasFailed)
                        TryMakeALap(driver);

                    if (driver.HasFailed)
                    {
                        failedDrivers[driver.Name] = driver;
                        registeredDrivers.Remove(driver.Name);
                    }
                }

                TryToOvertake(overtakes);
            }

            return string.Join(Environment.NewLine, overtakes);
        }

        else return $"There is no time! On lap {currentLap}.";
    }

    public string GetLeaderboard()
    {
        var sortedDrivers = registeredDrivers.Values.OrderBy(d => d.TotalTime)
            .Concat(failedDrivers.Values.Reverse())
            .ToList();

        var driversOutput = sortedDrivers.Select(d => $"{sortedDrivers.IndexOf(d) + 1} {d.Name} {(d.HasFailed ? d.FailureReason : d.TotalTime.ToString("F3"))}");

        var informaction = $"Lap {CurrentLap}/{lapsNumber}";

        if (driversOutput != null && driversOutput.Count() > 0)
            informaction += $"{Environment.NewLine}{string.Join(Environment.NewLine, driversOutput)}";

        return informaction;
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.weather = commandArgs[0];
    }

    /// <summary>
    /// Order drivers by speed and calculate which should overtake which
    /// </summary>
    /// <returns></returns>
    private void TryToOvertake(List<string> overtakes)
    {
        //Creating two sets to make sure drivers don't fight back
        var sortedDrivers = new Queue<Driver>(registeredDrivers.Values
            .OrderByDescending(d => d.TotalTime));

        while (sortedDrivers.Count > 1)
        {
            var driver = sortedDrivers.Dequeue();
            var driverToOvertake = sortedDrivers.Peek();

            double timeToAlter = Math.Abs(driver.TotalTime - driverToOvertake.TotalTime);


            bool canOvertake;
            if (driver is AggressiveDriver && driver.Car.Tyre is UltrasoftTyre)
            {
                canOvertake = timeToAlter <= 3;

                if (canOvertake && weather == "Foggy")
                {
                    driver.DeclareFailed("Crashed");

                    registeredDrivers.Remove(driver.Name);
                    failedDrivers[driver.Name] = driver;
                    continue;
                }

                timeToAlter = 3;
            }

            else if (driver is EnduranceDriver && driver.Car.Tyre is HardTyre)
            {
                canOvertake = timeToAlter <= 3;

                if (canOvertake && weather == "Rainy")
                {
                    driver.DeclareFailed("Crashed");

                    registeredDrivers.Remove(driver.Name);
                    failedDrivers[driver.Name] = driver;
                    continue;
                }

                timeToAlter = 3;
            }

            else
            {
                canOvertake = timeToAlter <= 2;
                timeToAlter = 2;
            }


            if (canOvertake)
            {
                driver.TotalTime -= timeToAlter;
                driverToOvertake.TotalTime += timeToAlter;

                //make sure the overtaken driver will not ne able to overtake anyone for the current lap
                sortedDrivers.Dequeue();

                overtakes.Add($"{driver.Name} has overtaken {driverToOvertake.Name} on lap {CurrentLap}.");
            }

        }
    }

    private void TryMakeALap(Driver driver)
    {
        try
        {
            driver.TotalTime += 60 / (trackLength / driver.Speed);
            driver.Car.DecreaseFuel(trackLength, driver.FuelConsumptionPerKm);
            driver.Car.Tyre.ReduceDegradation();
        }
        catch (ArgumentException e)
        {
            driver.DeclareFailed(e.Message);
        }
    }

}