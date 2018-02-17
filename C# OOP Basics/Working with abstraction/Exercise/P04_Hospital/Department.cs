using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Department
    {
        public string Name { get; set; }
        public HashSet<Patient> Patients { get; set; }
        public HashSet<Doctor> Doctors { get; set; }

        public Department(string name)
        {
            Name = name;
            Patients = new HashSet<Patient>();
            Doctors = new HashSet<Doctor>();
        }

        public IEnumerable<Patient> GetPatientsFromRoom(int roomNumber)
        {
            var numberOfPatientsToSkip = (roomNumber - 1) * 3;

            return Patients.Skip(numberOfPatientsToSkip).Take(3);
        }
    }
}
