using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Interpreter
{
    private Dictionary<string, Hardware> registeredHardware;
    private Dictionary<string, Hardware> dump;

    public Interpreter()
    {
        this.registeredHardware = new Dictionary<string, Hardware>();
        this.dump = new Dictionary<string, Hardware>();
    }

    public void RegisterHardware<THardware>(string name, int capacity, int memory) where THardware : Hardware
    {
        var hardwareInstance = Activator.CreateInstance(typeof(THardware), name, capacity, memory) as Hardware;

        this.registeredHardware[name] = hardwareInstance;
    }

    public void RegisterSoftware<TSoftware>(string hardwareComponentName, string name, int capacity, int memory) where TSoftware : Software
    {
        if (this.registeredHardware.ContainsKey(hardwareComponentName))
        {
            var software = Activator.CreateInstance(typeof(TSoftware), name, capacity, memory) as Software;

            this.registeredHardware[hardwareComponentName].RegisterSoftware(software);
        }
    }

    public void ReleaseSoftwareComponent(string hardwareComponentName, string softwareComponentName)
    {
        if (this.registeredHardware.ContainsKey(hardwareComponentName))
            this.registeredHardware[hardwareComponentName].ReleaseComponent(softwareComponentName);
    }

    public void Dump(string hardwareComponentName)
    {
        if (this.registeredHardware.ContainsKey(hardwareComponentName))
        {
            var hardwareToDump = this.registeredHardware[hardwareComponentName];

            this.registeredHardware.Remove(hardwareComponentName);
            this.dump[hardwareComponentName] = hardwareToDump;
        }
    }

    public void Restore(string hardwareComponentName)
    {
        if (this.dump.ContainsKey(hardwareComponentName))
        {
            var hardwareToRestore = this.dump[hardwareComponentName];

            this.dump.Remove(hardwareComponentName);
            this.registeredHardware[hardwareComponentName] = hardwareToRestore;
        }
    }


    public void Destroy(string hardwareComponentName)
    {
        if (this.dump.ContainsKey(hardwareComponentName))
            this.dump.Remove(hardwareComponentName);
    }

    public string DumpAnalyze()
    {
        var output = $"Dump Analysis{Environment.NewLine}" +
            $"Power Hardware Components: {this.dump.Where(dc => dc.Value is PowerHardware).Count()}{Environment.NewLine}" +
            $"Heavy Hardware Components: {this.dump.Where(dc => dc.Value is HeavyHardware).Count()}{Environment.NewLine}" +
            $"Express Software Components: {this.dump.Sum(dc => dc.Value.ExpressSoftwareCount)}{Environment.NewLine}" +
            $"Light Software Components: {this.dump.Sum(dc => dc.Value.LightSoftwareCount)}{Environment.NewLine}" +
            $"Total Dumped Memory: {this.dump.Sum(dc => dc.Value.CurrentMemory)}{Environment.NewLine}" +
            $"Total Dumped Capacity: {this.dump.Sum(dc => dc.Value.CurrentCapacity)}";

        return output;
    }

    public string Analyze()
    {
        var output = $"System Analysis{Environment.NewLine}" +
            $"Hardware Components: {this.registeredHardware.Count}{Environment.NewLine}" +
            $"Software Components: {this.registeredHardware.Sum(rh => rh.Value.SoftwareComponents.Count)}{Environment.NewLine}" +
            $"Total Operational Memory: {this.registeredHardware.Values.Sum(rh => rh.CurrentMemory)} / {this.registeredHardware.Values.Sum(rh => rh.MaximumMemory)}{Environment.NewLine}" +
            $"Total Capacity Taken: {this.registeredHardware.Values.Sum(rh => rh.CurrentCapacity)} / {this.registeredHardware.Values.Sum(rh => rh.MaximumCapacity)}";

        return output;
    }

    public string SystemSplit()
    {
        var output = new StringBuilder();

        foreach (var component in this.registeredHardware.Values)
            output.AppendLine(component.ToString());

        return output.ToString();
    }
}