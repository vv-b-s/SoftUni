using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        WriteLine(Receipt());
    }

    static string Receipt() => ReceiptHeader();

    static string ReceiptHeader() =>
        $"CASH RECEIPT\n" +
        $"------------------------------\n" +
        $"{ReceiptBody()}";

    static string ReceiptBody() =>
        $"Charged to____________________\n" +
        $"Received by___________________\n" +
        $"{ReceiptFooter()}";

    static string ReceiptFooter() =>
        $"------------------------------\n" +
        $"© SoftUni";
}
