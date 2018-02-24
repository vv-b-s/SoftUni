using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Mankind
{
    public class Student:Human
    {
        public string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber):base(firstName, lastName)
        {
            FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get => facultyNumber;
            set
            {
                if (!Regex.IsMatch(value, @"^[0-9A-Za-z]{5,10}$"))
                    throw new ArgumentException("Invalid faculty number!");

                else facultyNumber = value;
            }
        }

        public override string ToString() =>
            $"{base.ToString()}\n" +
            $"Faculty number: {facultyNumber}";
    }
}
