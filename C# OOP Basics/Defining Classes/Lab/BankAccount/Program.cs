using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;


class Program
{
    public static Dictionary<int, BankAccount> accounts;
    static void Main()
    {
        accounts = new Dictionary<int, BankAccount>();

        var input = "";

        while((input = ReadLine())!="End")
        {
            var args = input.Split();
            var command = args[0];
            var accountID = int.Parse(args[1]);

            switch(command)
            {
                case "Create":
                    Create(accountID);
                    break;
                case "Deposit":
                    Deposit(accountID, int.Parse(args[2]));
                    break;
                case "Withdraw":
                    Withdraw(accountID, int.Parse(args[2]));
                    break;
                case "Print":
                    if (accounts.ContainsKey(accountID))
                        WriteLine(accounts[accountID]);
                    else
                        WriteLine("Account does not exist");
                    break;
            }
        }
    }

    private static void Withdraw(int accountID, int amount)
    {
        if (accounts.ContainsKey(accountID) && !accounts[accountID].Withdraw(amount))
            WriteLine("Insufficient balance");
        else if (!accounts.ContainsKey(accountID))
            WriteLine("Account does not exist");
    }

    private static void Deposit(int accountID, int amount)
    {
        if (accounts.ContainsKey(accountID))
            accounts[accountID].Deposit(amount);
        else WriteLine("Account does not exist");
    }

    private static void Create(int accountID)
    {
        if (!accounts.ContainsKey(accountID))
            accounts[accountID] = new BankAccount(accountID);
        else WriteLine("Account already exists");
    }
}

