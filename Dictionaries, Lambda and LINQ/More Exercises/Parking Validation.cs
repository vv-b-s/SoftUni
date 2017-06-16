using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using static System.Console;

class Program
{
    static Dictionary<string,string> UserLicense = new Dictionary<string,string>();
    static void Main()
    {
       int numberOfCommands = int.Parse(ReadLine());

       for (int i = 0; i < numberOfCommands; i++)
       {
          string[] input = ReadLine().Split();
          string command = input[0];
          string username = input[1];
          string license = input.Length==3? input[2]:"";


          switch (command)
          {
             case "register":
                if (UserExists(username))
                   WriteLine($"ERROR: already registered with plate number {UserLicense[username]}");
                
                else if (!LicenseIsVerified(license))
                   WriteLine($"ERROR: invalid license plate {license}");
                   
                else if (UserEligableToRegister(license))
                   WriteLine($"ERROR: license plate {license} is busy");
                   
                else
                {
                   UserLicense[username] = license;
                   WriteLine($"{username} registered {license} successfully");
                }
                break;

             case "unregister":
                if (UserExists(username))
                {
                   WriteLine($"user {username} unregistered successfully");
                   UserLicense.Remove(username);
                }
                else
                   WriteLine($"ERROR: user {username} not found");
                break;
          }
       }

       if (UserLicense.Count > 0)
       {
          foreach (var user in UserLicense)
             WriteLine($"{user.Key} => {user.Value}");
       }
    }

   private static bool LicenseIsVerified(string license)
   {
      if (license.Length !=8)
         return false;
         
      string firstAndLastTwoLetters = new string(license.Take(2)
      .Concat(license.Skip(6).Take(2)).ToArray());
      if (firstAndLastTwoLetters.Any(c => char.IsLower(c)||char.IsNumber(c)||char.IsSymbol(c)))
         return false;
         
      string middle = new string(license.Skip(2).Take(4).ToArray());
      if (!middle.Any(n=>char.IsDigit(n)))
         return false;

      return true;
   }

   private static bool UserExists(string username) => UserLicense.ContainsKey(username);
   private static bool UserEligableToRegister(string license) => UserLicense.ContainsValue(license);
}