using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P07_FamilyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var familyTree = new List<Person>();
            string personInput = Console.ReadLine();
            Person mainPerson = new Person();

            if (IsBirthday(personInput))
                mainPerson.Birthday = personInput;

            else mainPerson.Name = personInput;

            familyTree.Add(mainPerson);

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" - ");

                if (tokens.Length > 1)
                {
                    string firstPerson = tokens[0];
                    string secondPerson = tokens[1];

                    Person currentPerson = GetCurrentPerson(familyTree, firstPerson, secondPerson); ;

                    if (IsBirthday(firstPerson))
                        currentPerson.Birthday = firstPerson;

                    else currentPerson.Name = firstPerson;
                }
                else
                {
                    tokens = tokens[0].Split();
                    string name = $"{tokens[0]} {tokens[1]}";
                    string birthday = tokens[2];

                    //Find if a copy of the person persists
                    var firstPersonCopy = familyTree.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);

                    //If it does try to remove all other copies
                    if (firstPersonCopy != null)
                    {
                        firstPersonCopy.Name = name;
                        firstPersonCopy.Birthday = birthday;

                        int index = familyTree.IndexOf(firstPersonCopy);

                        //Find all copies
                        var copies = familyTree.Where(p => (p.Name == name || p.Birthday == birthday) && p != firstPersonCopy).ToList();

                        foreach (var cpyPerson in copies)
                        {
                            //Remove the copy from the family tree
                            familyTree.Remove(cpyPerson);

                            //Get the data of the copy and apply it to the first copy
                            firstPersonCopy.Parents = firstPersonCopy.Parents.Concat(cpyPerson.Parents).ToHashSet();
                            firstPersonCopy.Children = firstPersonCopy.Children.Concat(cpyPerson.Children).ToHashSet();

                            //Replace the copy with the firstPerson in its parents and children
                            foreach (var parent in cpyPerson.Parents)
                                parent.Children = RemoveCopies(cpyPerson, firstPersonCopy, parent.Children);
                            foreach (var child in cpyPerson.Children)
                                child.Parents = RemoveCopies(cpyPerson, firstPersonCopy, child.Parents);
                        }
                    }
                    else familyTree.Add(new Person { Name = name, Birthday = birthday });
                }
            }

            var sB = new StringBuilder();
            sB.AppendLine(mainPerson.ToString());
            sB.AppendLine("Parents:");

            foreach (var parent in mainPerson.Parents)
                sB.AppendLine(parent.ToString());

            sB.AppendLine("Children:");
            foreach (var child in mainPerson.Children)
                sB.AppendLine(child.ToString());

            Console.Write(sB);
        }

        private static HashSet<Person> RemoveCopies(Person copy, Person original, HashSet<Person> originalSet)
        {
            var copySet = new HashSet<Person>();
            foreach(var person in originalSet)
            {
                if (person != copy)
                    copySet.Add(person);
                else
                    copySet.Add(original);
            }

            return copySet;
        }

        private static Person GetCurrentPerson(List<Person> familyTree, string firstPerson, string secondPerson)
        {
            var currentPerson = LookForPersonOrCreate(firstPerson, familyTree);

            //Set children for that person
            SetChild(familyTree, currentPerson, secondPerson);

            return currentPerson;
        }

        private static Person LookForPersonOrCreate(string personInfo, List<Person> familyTree)
        {
            //Look if there is repeating data about that person
            var currentPerson = familyTree.FirstOrDefault(p => p.Name == personInfo || p.Birthday == personInfo);

            //If there isn't create a new entry of that person
            if (currentPerson == null)
                AddPersonToFalilyTree(out currentPerson, familyTree);

            return currentPerson;
        }

        private static void AddPersonToFalilyTree(out Person currentPerson, List<Person> familyTree)
        {
            currentPerson = new Person();
            familyTree.Add(currentPerson);
        }

        private static void SetChild(List<Person> familyTree, Person parentPerson, string child)
        {
            var childPerson = LookForPersonOrCreate(child, familyTree);

            if (IsBirthday(child))
                childPerson.Birthday = child;

            else childPerson.Name = child;

            parentPerson.Children.Add(childPerson);
            childPerson.Parents.Add(parentPerson);
        }

        static bool IsBirthday(string input) => Char.IsDigit(input[0]);
    }
}
