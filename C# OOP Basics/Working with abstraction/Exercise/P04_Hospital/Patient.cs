using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Patient
    {
        public string Name { get; set; }
        public Doctor Doctor { get; set; }
        public Department Department { get; set; }

        public Patient(string name, Doctor doctor, Department department)
        {
            Name = name;
            Doctor = doctor;
            Department = department;

            doctor.Patients.Add(this);
            department.Patients.Add(this);
        }

        public override string ToString() => Name;
    }
}
