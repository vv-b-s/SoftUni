namespace Tire_Pressure_Monitoring_System.App.Contracts
{
    public interface IAlarm
    {
        bool AlarmOn { get; }

        void Check();
    }
}