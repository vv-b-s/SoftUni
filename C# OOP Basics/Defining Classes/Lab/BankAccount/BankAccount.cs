using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BankAccount
{
    private int id;

    public int Id { get; set; }
    public decimal Balance { get; set; }

    public BankAccount() { }

    public BankAccount(int id)
    {
        Id = id;
    }

    public void Deposit(decimal amount) => Balance += amount;
    public bool Withdraw(decimal amount)
    {
        if (Balance < amount)
            return false;

        Balance -= amount;
        return true;
    }

    public override string ToString() => $"Account ID {Id}, balance {Balance}";
}
