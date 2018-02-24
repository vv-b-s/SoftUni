using System;

namespace Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var studentData = Console.ReadLine().Split();
                var workerData = Console.ReadLine().Split();

                var student = new Student(firstName: studentData[0], lastName: studentData[1], facultyNumber: studentData[2]);
                var worker = new Worker(firstName: workerData[0], lastName: workerData[1], weekSalary: decimal.Parse(workerData[2]), workHoursPerDay: decimal.Parse(workerData[3]));

                Console.WriteLine(student + "\n");
                Console.WriteLine(worker);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
