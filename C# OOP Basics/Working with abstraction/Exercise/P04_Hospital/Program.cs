using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            var doctors = new Dictionary<string, Doctor>();
            var departments = new Dictionary<string, Department>();

            var command = "";
            while ((command = Console.ReadLine()) != "Output")
            {
                string[] tokens = command.Split();
                var department = tokens[0];
                var doctorFirstName = tokens[1];
                var doctorLastName = tokens[2];
                var patient = tokens[3];
                var doctorName = doctorFirstName + ' ' + doctorLastName;

                if (!departments.ContainsKey(department))
                    departments[department] = new Department(department);

                if (!doctors.ContainsKey(doctorName))
                    doctors[doctorName] = new Doctor(doctorName);

                doctors[doctorName].Departments.Add(departments[department]);
                departments[department].Doctors.Add(doctors[doctorName]);

                bool patientCanBePlaced = departments[department].Patients.Count< 60;

                if (patientCanBePlaced)
                    departments[department].Patients.Add(new Patient(patient, doctors[doctorName], departments[department]));
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] args = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (args.Length == 1)
                    PrintPatients(departments[args[0]].Patients);

                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                    PrintPatients(departments[args[0]].GetPatientsFromRoom(room).OrderBy(p => p.Name));

                else PrintPatients(doctors[args[0] + ' ' + args[1]].Patients.OrderBy(p => p.Name));   
            }
        }

        private static void PrintPatients(IEnumerable<Patient> patients) => Console.WriteLine(string.Join("\n", patients));
    }
}
