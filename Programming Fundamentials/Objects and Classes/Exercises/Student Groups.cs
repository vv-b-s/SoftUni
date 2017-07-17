using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using static System.Console;

class Student
{
    public string Name { set; get; }
    public string Email { set; get; }
    public DateTime RegistrationDate { set; get; }

    public Student(string name, string email, string regDate)
    {
        Name = name;
        Email = email;
        RegistrationDate = DateTime.ParseExact(regDate, "d-MMM-yyyy", CultureInfo.InvariantCulture);
    }
}

class Seats
{
    private List<Student> students = new List<Student>();

    public string Town { set; get; }
    public int NumberOfSeats { set; get; }
    public int NumberOfGroups { set; get; }
    public List<List<string>> Distribution;

    public Seats(string town, int numberOfSeats)
    {
        Town = town;
        NumberOfSeats = numberOfSeats;
    }

    public void AddStudent(string name, string email, string regDate) => 
        students.Add(new Student(name, email, regDate));

    public void GenerateDistribution()
    {
        students = students.OrderBy(s => s.RegistrationDate.Date)
            .ThenBy(s => s.Name)
            .ThenBy(s=>s.Email)
            .ToList();

        Distribution = new List<List<string>>();
        var TempList = new List<string>();
        for(int i=0;i<students.Count;i++)
        {
            TempList.Add(students[i].Email);
            if(TempList.Count==NumberOfSeats)
            {
                Distribution.Add(TempList);
                TempList = new List<string>();
            }
            if (i == students.Count - 1 && TempList.Count != 0)
                Distribution.Add(TempList);
        }

        NumberOfGroups = Distribution.Count();
    }
}

class Program
{
    static void Main()
    {
        var seatsList = new List<Seats>();
        string input;
        while((input=ReadLine())!="End")
        {
            if(input.Contains("=>"))
            {
                string[] temp = input.Split('=', '>').Where(i => i != "").ToArray();
                string town = temp[0].Trim();
                int seats = int.Parse(temp[1].Trim().Split()[0]);
                seatsList.Add(new Seats(town, seats));
            }
            else
            {
                string[] temp = input.Split('|');
                string studentName = temp[0].Trim();
                string studentEmail = temp[1].Trim();
                string regDate = temp[2].Trim();
                seatsList.Last().AddStudent(studentName, studentEmail, regDate);
            }
        }

        seatsList = seatsList.OrderBy(t => t.Town).ToList();

        foreach (var seat in seatsList)
            seat.GenerateDistribution();

        WriteLine($"Created {seatsList.Sum(s=>s.NumberOfGroups)} groups in {seatsList.Count} towns:");
        foreach(var seat in seatsList)
            foreach (var group in seat.Distribution)
                WriteLine($"{seat.Town} => {string.Join(", ", group)}");
    }
}