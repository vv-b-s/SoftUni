using System;
using System.Collections.Generic;
using WorkForce.Contracts;
using WorkForce.Models;

namespace WorkForce
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new Dictionary<string, IEmployee>();
            var jobHandler = new JobHandler();

            var input = "";
            while((input=Console.ReadLine())!="End")
            {
                var data = input.Split();

                if (data[0].Contains("Employee"))
                {
                    var name = data[1];
                    var employee = Activator.CreateInstance(Type.GetType($"WorkForce.Models.{data[0]}"), name) as IEmployee;
                    employees[name] = employee;
                }

                else if (data[0] == "Job")
                {
                    var jobName = data[1];
                    var workHours = int.Parse(data[2]);
                    var employee = employees[data[3]];

                    jobHandler.RegisterJob(new Job(jobName, workHours, employee));
                }

                else if (data[0] == "Pass")
                    jobHandler.PassWeek();

                else if (data[0] == "Status")
                    jobHandler.GetJobsStatus();
            }
        }
    }
}
