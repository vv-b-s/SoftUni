using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Family
{
    public List<Person> Members { get; set; }

    public Family()
    {
        Members = new List<Person>();
    }

    public Family(params Person[] members):this()
    {
        foreach (var person in members)
            Members.Add(person);
    }


    /// <summary>
    /// Adds a member to the list of family members
    /// </summary>
    /// <param name="member"></param>
    public void AddMember(Person member)
    {
        Members.Add(member);
    }

    /// <summary>
    /// Finds the first oldest member in the family or returns null if there is no such
    /// </summary>
    /// <returns></returns>
    public Person GetOldestMember() => Members.FirstOrDefault(m => m.Age == Members.Max(me => me.Age));

    /// <summary>
    /// Gets the members aged over certain age and sorts them alphabetically
    /// </summary>
    /// <param name="ageLimit"></param>
    /// <returns></returns>
    public List<Person> GetSortedMembersWithAgeAbove(int ageLimit) => Members.Where(m => m.Age > ageLimit).OrderBy(m => m.Name).ToList();
}

