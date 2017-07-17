using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using static System.Console;

class Student
{
    private List<double> grades = new List<double>();

    public string Name { set; get; }
    public double GPA => grades.Average();

    public Student(string name, List<double> grades)
    {
        Name = name;
        this.grades = grades;
    }

    public static string PrintStudentsWithHighGPA(List<Student> students)
    {
        students = students.Where(s => s.GPA >= 5.00).OrderBy(s => s.Name).ThenByDescending(s => s.GPA).ToList();

        var gradesStringList = new StringBuilder();
        foreach (var student in students)
            gradesStringList.AppendLine($"{student.Name} -> {student.GPA:f2}");

        return gradesStringList.ToString();
    }
}

class Program
{
    static void Main()
    {
        var students = new List<Student>();

        for(int i =int.Parse(ReadLine());i>0;i--)
        {
            var input = ReadLine().Split().ToList();
            string name = input[0];
            input.RemoveAt(0);
            List<double> grades = input.Select(double.Parse).ToList();

            students.Add(new Student(name, grades));
        }

        WriteLine(Student.PrintStudentsWithHighGPA(students));
    }
}