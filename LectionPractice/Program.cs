using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class CountSameValuesInArray
{
    static void Main()
    {
        var numberOfStudents = int.Parse(ReadLine());
        var studentsData = new SortedDictionary<string, double[]>();

        while(numberOfStudents-->0)
        {
            string studentName = ReadLine();
            double[] studentGrades = ReadLine().Split(' ').Where(i=>i!="").Select(double.Parse).ToArray();
            studentsData[studentName] = studentGrades;
        }

        foreach (var student in studentsData)
            WriteLine($"{student.Key} is graduated with {student.Value.Average()}");
    }
}
