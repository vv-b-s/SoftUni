using System;
using System.Collections.Generic;
using System.Text;

namespace WorkForce.Contracts
{
    public interface IJobHandler : IEnumerable<IJob>
    {
        IReadOnlyCollection<IJob> Jobs { get; }

        void RegisterJob(IJob job);

        void HandleJobUpdate(object sender, EventArgs e);

        void GetJobsStatus();

        void PassWeek();
    }
}
