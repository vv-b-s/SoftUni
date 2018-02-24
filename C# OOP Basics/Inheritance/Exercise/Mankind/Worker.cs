using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Worker:Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay) :base(firstName, lastName)
        {
            WeekSalery = weekSalary;
            WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalery
        {
            get => weekSalary;
            set
            {
                ValidateWorkerData(nameof(weekSalary), value, () => value > 10);
                weekSalary = value;
            }
        }

        public decimal WorkHoursPerDay
        {
            get => workHoursPerDay;
            set
            {
                ValidateWorkerData(nameof(workHoursPerDay), value, () => value >= 1 && value <= 12);
                workHoursPerDay = value;
            }
        }

        public decimal HourlySalary => weekSalary / (workHoursPerDay * 5);

        public override string ToString() =>
            $"{base.ToString()}\n" +
            $"Week Salary: {weekSalary:F2}\n" +
            $"Hours per day: {workHoursPerDay:F2}\n" +
            $"Salary per hour: {HourlySalary:F2}";

        private void ValidateWorkerData(string variableName, decimal value, Func<bool> isValid)
        {
            if (!isValid())
                throw new ArgumentException($"Expected value mismatch! Argument: {variableName}");
        }
    }
}
