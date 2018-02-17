using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Doctor
    {
        public string Name { get; set; }
        public HashSet<Patient> Patients { get; set; }
        public HashSet<Department> Departments { get; set; }

        public Doctor(string name)
        {
            Name = name;
            Patients = new HashSet<Patient>();
            Departments = new HashSet<Department>();
        }
    }
}
