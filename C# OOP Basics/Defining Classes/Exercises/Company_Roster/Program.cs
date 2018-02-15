using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Company_Roster
{
    class Program
    {
        static void Main(string[] args)
        {
            var departmentEmployees = new Dictionary<string, List<Employee>>();

            var numberOfEmployeesToAdd = int.Parse(ReadLine());

            while (numberOfEmployeesToAdd-- > 0)
            {
                var inputData = ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = inputData[0];
                var salary = decimal.Parse(inputData[1]);
                var position = inputData[2];
                var department = inputData[3];

                if (!departmentEmployees.ContainsKey(department))
                    departmentEmployees[department] = new List<Employee>();

                if (inputData.Length == 6)
                {
                    var email = inputData[4];
                    var age = int.Parse(inputData[5]);

                    departmentEmployees[department].Add(new Employee(name, salary, position, department, email, age));
                }
                else if (inputData.Length < 6)
                {
                    if (inputData.Length == 5)
                    {
                        if (int.TryParse(inputData[4], out int age))
                            departmentEmployees[department].Add(new Employee(name, salary, position, department, age));
                        else
                        {
                            var email = inputData[4];
                            departmentEmployees[department].Add(new Employee(name, salary, position, department, email));
                        }
                    }
                    else
                        departmentEmployees[department].Add(new Employee(name, salary, position, department));
                }
            }

            var highestAverageSalaryDepartment = GetAverageSalaryDepartment(departmentEmployees);

            WriteLine($"Highest Average Salary: {highestAverageSalaryDepartment.Key}\n" +
                $"{string.Join("\n", departmentEmployees[highestAverageSalaryDepartment.Key].OrderByDescending(e => e.Salary))}");
        }

        private static KeyValuePair<string, decimal> GetAverageSalaryDepartment(Dictionary<string, List<Employee>> departmentEmployees)
        {
            var departmentsAverageSalary = new Dictionary<string, decimal>();

            foreach (var department in departmentEmployees)
                departmentsAverageSalary[department.Key] = department.Value.Average(e => e.Salary);

            return departmentsAverageSalary.Where(das => das.Value == departmentsAverageSalary.Max(d => d.Value)).First();
        }
    }
}
