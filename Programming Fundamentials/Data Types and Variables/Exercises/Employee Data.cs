using System;
using System.Globalization;
using System.Text;
using static System.Console;

public class Employee
{
    public string FirstName { set; get; }
    public string LastName { set; get; }
    public int Age { set; get; }
    public char Gender { set; get; }
    public ulong PIDN { set; get; }
    public ulong UniqueEmployeeNumber { set; get; }

    public Employee(string firstName, string lastName, string age, string gender, string pidn, string uen)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = int.Parse(age);
        Gender = char.Parse(gender);
        PIDN = ulong.Parse(pidn);
        UniqueEmployeeNumber = ulong.Parse(uen);
    }

    public override string ToString() => $"First name: {FirstName}\n" +
                                         $"Last name: {LastName}\n" +
                                         $"Age: {Age}\n" +
                                         $"Gender: {Gender}\n" +
                                         $"Personal ID: {PIDN}\n" +
                                         $"Unique Employee number: {UniqueEmployeeNumber}\n";

}

class Program
{
    static void Main()
    {
        Employee emp1 = new Employee(ReadLine(),ReadLine(),ReadLine(),ReadLine(),ReadLine(),ReadLine());
        Write(emp1.ToString());
    }

}
