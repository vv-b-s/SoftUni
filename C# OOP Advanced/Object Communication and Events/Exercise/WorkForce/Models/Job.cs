using System;
using System.Collections.Generic;
using System.Text;
using WorkForce.Contracts;

namespace WorkForce.Models
{
    public class Job : IJob
    {
        public Job(string jobName, int workHours, IEmployee employee)
        {
            this.Name = jobName;
            this.RequiredWorkHours = workHours;
            this.Employee = employee;
        }

        public string Name { get; }

        public int RequiredWorkHours { get; private set; }

        public IEmployee Employee { get; }

        public event JobUpdateHandler JobUpdate;

        public void Update()
        {
            this.RequiredWorkHours -= this.Employee.WorkingHoursPerWeek;
            OnJobUpdate(new EventArgs());
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.RequiredWorkHours}";
        }

        protected void OnJobUpdate(EventArgs e)
        {
            this.JobUpdate(this, e);
        }
    }
}
