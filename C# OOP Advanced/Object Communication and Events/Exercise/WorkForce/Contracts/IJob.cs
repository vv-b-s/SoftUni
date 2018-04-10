using System;
using System.Collections.Generic;
using System.Text;

namespace WorkForce.Contracts
{
    public delegate void JobUpdateHandler(object sender, EventArgs e);
    public interface IJob
    {
        event JobUpdateHandler JobUpdate;

        string Name { get; }
        int RequiredWorkHours { get; }
        IEmployee Employee { get; }


        void Update();
    }
}
