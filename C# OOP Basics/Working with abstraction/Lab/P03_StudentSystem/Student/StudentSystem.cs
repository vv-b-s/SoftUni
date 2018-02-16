using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem.Student
{
    public class StudentSystem
    {
        public Dictionary<string, Student> Repo { get; set; }

        public StudentSystem()
        {
            Repo = new Dictionary<string, Student>();
        }

        /// <summary>
        /// Get the comand and do an action. Returns false if 'Exit' is received
        /// </summary>
        /// <returns>bool</returns>
        public bool ParseCommand()
        {
            string[] args = Console.ReadLine().Split();

            if (args[0] == "Create")
                Create(args);

            else if (args[0] == "Show")
                Show(args);

            else if (args[0] == "Exit")
                return false;

            return true;
        }

        /// <summary>
        /// Creates a record of the student
        /// </summary>
        /// <param name="args"></param>
        private void Create(string[] args)
        {
            var name = args[1];
            var age = int.Parse(args[2]);
            var grade = double.Parse(args[3]);

            if (!Repo.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                Repo[name] = student;
            }
        }

        /// <summary>
        /// Show data about a student
        /// </summary>
        /// <param name="args"></param>
        private void Show(string[] args)
        {
            var name = args[1];
            if (Repo.ContainsKey(name))
            {
                var student = Repo[name];
                var view = new StringBuilder($"{student.Name} is {student.Age} years old.");

                if (student.Grade >= 5.00)
                    view.Append(" Excellent student.");
                
                else if (student.Grade < 5.00 && student.Grade >= 3.50)
                    view.Append(" Average student.");
                
                else view.Append(" Very nice person.");
                

                Console.WriteLine(view);
            }
        }
    }
}
