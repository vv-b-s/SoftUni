using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
        var inText = File.ReadAllLines(@"X:\Development\SoftUni\Files, Directories and Exceptions\Exercises\Average Grades\input.txt");
        List<string>[] texts =
        {
            inText.TakeWhile(s => s != "").ToList(),
            inText.SkipWhile(s => s != "").ToList()
        };

        texts[1].RemoveAt(0);

        var sB = new StringBuilder();    

        foreach (var text in texts)
        {
            var students = new List<Student>();

            for (int i = 1; i < text.Count; i++)
            {
                var input = text[i].Split().ToList();
                string name = input[0];
                input.RemoveAt(0);
                List<double> grades = input.Select(double.Parse).ToList();

                students.Add(new Student(name, grades));
            }

            sB.AppendLine(Student.PrintStudentsWithHighGPA(students)+"\n"); 
        }
        File.WriteAllText(@"X:\Development\SoftUni\Files, Directories and Exceptions\Exercises\Average Grades\output.txt", sB.ToString());
    }
}