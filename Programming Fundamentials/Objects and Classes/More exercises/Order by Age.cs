using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using static System.Console;

 
class Person
{
    public string Name { get; set; }
    public int Age { set; get; }
    public string ID { get; set; }

    public Person(string name, string id, int age)
    {
        Name = name;
        ID = id;
        Age = age;
    }
}

class Program
{
    static void Main()
    {
        var people = new List<Person>();

        string input;
        while((input=ReadLine())!="End")
        {
            string[] temp = input.Split();
            string name = temp[0];
            string id = temp[1];
            int age = int.Parse(temp[2]);
            people.Add(new Person(name, id, age));
        }

        people = people.OrderBy(p => p.Age).ToList();

        foreach (var person in people)
            WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
    }
}