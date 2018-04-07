using Integration_Tests.App.Model;
using System;
using System.Linq;

namespace Integration_Tests.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var categoeies = new Category[4];

            var users = new User[4];

            for (int i = 0; i < users.Length; i++)
            {
                categoeies[i] = new Category($"category{i}");
                users[i] = new User($"user{i}");
            }

            categoeies[0].AddSubcategories(categoeies[1], categoeies[2]);
            categoeies[0].AddUsers(users[0]);

            categoeies[1].AddUsers(users[0]);

            Console.WriteLine(string.Join(" ", users[0].Categories.Select(c => c.Name)));

            categoeies[0].RemoveCategory();

            Console.WriteLine(string.Join(" ", users[0].Categories.Select(c => c.Name)));
        }
    }
}
