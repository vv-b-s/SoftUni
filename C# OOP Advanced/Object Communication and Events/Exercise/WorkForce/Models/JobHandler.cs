using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WorkForce.Contracts;

namespace WorkForce.Models
{
    class JobHandler : IJobHandler
    {
        private List<IJob> jobs;

        public JobHandler()
        {
            this.jobs = new List<IJob>();
        }

        public void RegisterJob(IJob job)
        {
            this.jobs.Add(job);
            job.JobUpdate += HandleJobUpdate;
        }

        public IReadOnlyCollection<IJob> Jobs => this.jobs;

        public void HandleJobUpdate(object sender, EventArgs e)
        {
            var job = sender as IJob;

            if (job.RequiredWorkHours <= 0)
            {
                this.jobs.Remove(job);

                Console.WriteLine($"Job {job.Name} done!");
            }
        }


        public void GetJobsStatus()
        {
            foreach (var job in this)
                Console.WriteLine(job);
        }

        public void PassWeek()
        {
            var copy = new List<IJob>(this);
            foreach (var job in copy)
                job.Update();
        }

        public IEnumerator<IJob> GetEnumerator()
        {
            foreach (var job in this.jobs)
                yield return job;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return GetEnumerator();
        }
    }
}
