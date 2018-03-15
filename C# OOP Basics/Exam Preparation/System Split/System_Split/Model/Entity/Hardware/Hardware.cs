using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Hardware : IHardware
{
    private string name;

    private int currentCapacity;
    private int currentMemory;

    private int maximumCapacity;
    private int maximumMemory;

    private Dictionary<string, Software> softwareComponents;

    protected Hardware(string name, int maximumCapacity, int maximumMemory)
    {
        this.Name = name;
        this.MaximumCapacity = maximumCapacity;
        this.MaximumMemory = maximumMemory;
        this.softwareComponents = new Dictionary<string, Software>();
    }

    public IReadOnlyDictionary<string, Software> SoftwareComponents => this.softwareComponents;

    public string Name
    {
        get => this.name;
        protected set => this.name = value;
    }

    public int MaximumCapacity
    {
        get => this.maximumCapacity;
        protected set => this.maximumCapacity = value;
    }

    public int MaximumMemory
    {
        get => this.maximumMemory;
        protected set => this.maximumMemory = value;
    }

    public int CurrentCapacity
    {
        get => this.currentCapacity;
        protected set => this.currentCapacity = value;
    }

    public int CurrentMemory
    {
        get => this.currentMemory;
        protected set => this.currentMemory = value;
    }

    public int ExpressSoftwareCount => this.SoftwareComponents.Where(sc => sc.Value is ExpressSoftware).Count();

    public int LightSoftwareCount => this.SoftwareComponents.Where(sc => sc.Value is LightSoftware).Count();

    public void RegisterSoftware(Software software)
    {
        var freeCapacity = this.MaximumCapacity - this.CurrentCapacity;
        var freeMemory = this.MaximumMemory - this.CurrentMemory;

        if (software.CapacityConsumption <= freeCapacity && software.MemoryConsumption <= freeMemory)
        {
            this.softwareComponents[software.Name] = software;

            this.CurrentMemory += software.MemoryConsumption;
            this.CurrentCapacity += software.CapacityConsumption;
        }
    }

    public void ReleaseComponent(string softwareComponentName)
    {
        if (this.softwareComponents.ContainsKey(softwareComponentName))
        {
            var software = this.softwareComponents[softwareComponentName];

            this.CurrentCapacity -= software.CapacityConsumption;
            this.CurrentMemory -= software.MemoryConsumption;

            this.softwareComponents.Remove(softwareComponentName);
        }
    }

    public override string ToString()
    {
        var escCount = this.softwareComponents.Values.Where(sc => sc is ExpressSoftware).Count();
        var lscCount = this.softwareComponents.Values.Where(sc => sc is LightSoftware).Count();

        var output = $"Hardware Component - {this.name}{Environment.NewLine}" +
            $"Express Software Components - {escCount.ToString()}{Environment.NewLine}" +
            $"Light Software Components - {lscCount.ToString()}{Environment.NewLine}" +
            $"Memory Usage: {this.CurrentMemory} / {this.MaximumMemory}{Environment.NewLine}" +
            $"Capacity Usage: {this.CurrentCapacity} / {this.MaximumCapacity}{Environment.NewLine}" +
            $"Type: {this.GetType().Name.Substring(0, this.GetType().Name.LastIndexOf("Hardware"))}{Environment.NewLine}" +
            $"Software Components: {(escCount + lscCount > 0 ? string.Join(", ", this.softwareComponents.Keys) : "None")}";

        return output;
    }
}