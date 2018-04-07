using Tire_Pressure_Monitoring_System.App.Contracts;

namespace Tire_Pressure_Monitoring_System.App.Models
{
    public class Alarm : IAlarm
    {
        public const double LowPressureThreshold = 17;
        public const double HighPressureThreshold = 21;

        readonly ISensor _sensor;

        bool _alarmOn = false;

        public Alarm(ISensor sensor)
        {
            this._sensor = sensor;
        }

        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }

    }
}
