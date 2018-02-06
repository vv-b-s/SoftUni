using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var departmentsDoctorsPatients = new Dictionary<string, Dictionary<string, List<string>>>();
        var departmentsPatients = new Dictionary<string, List<string>>();
        var departmentsRoomsPatients = new Dictionary<string, List<List<string>>>();

        string input;
        var waitingForOutput = false;
        while ((input = ReadLine()) != "End")
        {

            if (input != "Output" && !waitingForOutput)
            {
                var data = input.Split().Where(i => i != "").ToArray();
                var department = data[0];
                var doctor = data[1] + " " + data[2];
                var patient = data[3];

                if (!departmentsDoctorsPatients.ContainsKey(department))
                {
                    departmentsDoctorsPatients[department] = new Dictionary<string, List<string>>();
                    departmentsPatients[department] = new List<string>();
                    departmentsRoomsPatients[department] = new List<List<string>>();
                }

                if (departmentsRoomsPatients[department].Count <= 20)
                {
                    var room = departmentsRoomsPatients[department].LastOrDefault();
                    if (room is null || (room.Count == 3 && departmentsRoomsPatients[department].Count < 20))
                    {
                        room = new List<string>();
                        departmentsRoomsPatients[department].Add(room);
                    }

                    if (room.Count < 3)
                    {
                        room.Add(patient);
                        departmentsPatients[department].Add(patient);

                        if (!departmentsDoctorsPatients[department].ContainsKey(doctor))
                            departmentsDoctorsPatients[department][doctor] = new List<string>();

                        departmentsDoctorsPatients[department][doctor].Add(patient);
                    }
                }

            }
            else if(input=="Output")
            {
                waitingForOutput = true;
                continue;
            }
            else
            {
                input = input.Trim(' ');

                //If the input exists as a department key it is probably a department
                if (departmentsPatients.ContainsKey(input))
                {
                    WriteLine(string.Join("\n", departmentsPatients[input]));
                }

                //If the input exists as a Doctor name it is probably a doctor
                else if (departmentsDoctorsPatients.Values.Any(v => v.ContainsKey(input)))
                {
                    //Get all the patients of this toctor
                    IEnumerable<string> patients = new List<string>();
                    foreach(var department in departmentsDoctorsPatients)
                    {
                        foreach(var doctor in department.Value)
                        {
                            if (doctor.Key == input)
                                patients = patients.Concat(doctor.Value);                            
                        }
                    }

                    patients = patients.OrderBy(p => p);
                    WriteLine(string.Join("\n", patients));
                }
                //Otherwise it is probably a query for room
                else
                {
                    var data = input.Split().Where(i => i != "").ToArray();
                    var department = data[0];
                    var roomNumber = int.Parse(data[1]);

                    if (departmentsRoomsPatients.ContainsKey(department) && departmentsRoomsPatients[department].Count >= roomNumber)
                    {
                        WriteLine(string.Join("\n", departmentsRoomsPatients[department][roomNumber - 1].OrderBy(p => p)));
                    }
                }
            }
        }
    }
}
