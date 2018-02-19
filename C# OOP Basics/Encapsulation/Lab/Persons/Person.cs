using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Salary = salary;
    }

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (NameIsValid(value))
                firstName = value;
            else throw new ArgumentException("First name cannot contain fewer than 3 symbols!”");
        }
    }

    public string LastName
    {
        get { return lastName; }
        set
        {
            if (NameIsValid(value))
                lastName = value;
            else throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value > 0)
                age = value;
            else throw new ArgumentException("Age cannot be zero or a negative integer!");
        }
    }

    public decimal Salary
    {
        get { return salary; }
        set
        {
            if (value >= 460)
                salary = value;
            else throw new ArgumentException("Salary cannot be less than 460 leva!");
        }
    }

    public void IncreaseSalary(decimal percentage)
    {
        var division = Age > 30 ? 100 : 200;

        var bonus = percentage / division + 1;
        salary *= bonus;
    }

    public override string ToString() => $"{FirstName} {LastName} receives {salary:F2} leva.";

    private static bool NameIsValid(string name) => name.Length >= 3;
}
