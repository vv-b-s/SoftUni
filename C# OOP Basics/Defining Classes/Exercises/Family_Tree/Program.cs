using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Family_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var familyTree = new Dictionary<string, Person>();

            var firstPersonData = Console.ReadLine();

            familyTree[firstPersonData] = new Person();
            familyTree[firstPersonData].AddMemberDetail(firstPersonData);

            var input = "";
            var splitPattern = new Regex(@"\s-\s");
            while ((input = Console.ReadLine()) != "End")
            {
                if (splitPattern.IsMatch(input))
                {

                    var inputData = splitPattern.Split(input);

                    //Get the data for the parent and child
                    var parent = inputData[0];
                    var child = inputData[1];

                    Person parentMember;
                    Person childMember;

                    //Check if they exist in the dictionary
                    if (!familyTree.ContainsKey(parent))
                    {
                        if (familyTree.Values.Any(p => p.Name == parent || p.Birthdate == parent))
                            parentMember = familyTree.Values.First(p => p.Name == parent || p.Birthdate == parent);
                        else
                        {
                            familyTree[parent] = new Person();
                            parentMember = familyTree[parent];
                        }
                    }
                    else parentMember = familyTree[parent];

                    if (!familyTree.ContainsKey(child))
                    {
                        if (familyTree.Values.Any(p => p.Name == child || p.Birthdate == child))
                            childMember = familyTree.Values.First(p => p.Name == child || p.Birthdate == child);
                        else
                        {
                            familyTree[child] = new Person();
                            childMember = familyTree[child];
                        }

                    }
                    else childMember = familyTree[child];

                    //Add the new details about the parent and the child (either birthday or name)
                    parentMember.AddMemberDetail(parent);
                    childMember.AddMemberDetail(child);

                    //recognize the parent as a parent of the child
                    parentMember.Children.Add(childMember);
                    childMember.Parents.Add(parentMember);

                }
                else
                {
                    //The name of the person is in the first two elements of the array
                    var name = string.Join(" ", input.Split().Take(2));

                    //The birthdate is in the last element of the array
                    var birthdate = input.Split().Last();

                    if (familyTree.ContainsKey(name))
                    {
                        familyTree[name].AddMemberDetail(birthdate);
                        if (familyTree.ContainsKey(birthdate))
                            NormalizeData(familyTree, name, birthdate);
                    }
                    else if (familyTree.ContainsKey(birthdate))
                    {
                        familyTree[birthdate].AddMemberDetail(name);
                        if (familyTree.ContainsKey(name))
                            NormalizeData(familyTree, name, birthdate);
                    }
                    else
                    {
                        familyTree[name] = new Person
                        {
                            Name = name,
                            Birthdate = birthdate
                        };
                    }
                }
            }

            Console.WriteLine(familyTree[firstPersonData]);

            Console.WriteLine("Parents:");
            if (familyTree[firstPersonData].Parents.Count > 0)
                Console.WriteLine(string.Join("\n", familyTree[firstPersonData].Parents));

            Console.WriteLine("Children:");
            if (familyTree[firstPersonData].Children.Count > 0)
                Console.WriteLine(string.Join("\n", familyTree[firstPersonData].Children));
        }

        /// <summary>
        /// Distincts repeating entries
        /// </summary>
        /// <param name="familyTree"></param>
        /// <param name="name"></param>
        /// <param name="birthdate"></param>
        private static void NormalizeData(Dictionary<string, Person> familyTree, string name, string birthdate)
        {
            var keys = familyTree.Keys.ToArray();
            var indexOfName = Array.IndexOf(keys, name);
            var indexOfBirthdate = Array.IndexOf(keys, birthdate);

            if (indexOfName < indexOfBirthdate)
            {
                familyTree[name].Birthdate = birthdate;
                familyTree[name].Parents = familyTree[name].Parents.Concat(familyTree[birthdate].Parents).ToList();
                familyTree[name].Children = familyTree[name].Children.Concat(familyTree[birthdate].Children).ToList();

                familyTree.Remove(birthdate);
            }
            else
            {
                familyTree[birthdate].Name = name;
                familyTree[birthdate].Parents = familyTree[birthdate].Parents.Concat(familyTree[name].Parents).ToList();
                familyTree[birthdate].Children = familyTree[birthdate].Children.Concat(familyTree[name].Children).ToList();

                familyTree.Remove(name);
            }
        }
    }
}
