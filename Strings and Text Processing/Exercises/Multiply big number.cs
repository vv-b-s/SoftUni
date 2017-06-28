using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Globalization;

class BigNumber
{
    Stack<sbyte> number = new Stack<sbyte>();

    public BigNumber(string number)
    {
        var numberList = number.Select(n => (sbyte)char.GetNumericValue(n)).ToArray();
        foreach (var digit in numberList)
            this.number.Push(digit);
    }

    public static BigNumber operator +(BigNumber bn1, BigNumber bn2)
    {
        var bn = new BigNumber[] { bn1, bn2 }.OrderBy(n => n.number.Count).ToArray();
        var smallestNumberLength = bn[0].number.Count;

        var newNumber = new Stack<sbyte>();
        sbyte remainder = 0;

        #region Summing digits
        for (int i = 0; i < smallestNumberLength; i++)
        {
            var sumNumbers = (sbyte)(bn[0].number.Pop() + bn[1].number.Pop() + remainder);
            remainder = (sbyte)(sumNumbers / 10);
            sumNumbers %= 10;

            newNumber.Push(sumNumbers);
        }

        while (bn[1].number.Count > 0)
        {
            var sumNumbers = (sbyte)(bn[1].number.Pop() + remainder);
            remainder = (sbyte)(sumNumbers / 10);
            sumNumbers %= 10;
            newNumber.Push(sumNumbers);
        }

        if (remainder != 0)
            newNumber.Push(remainder);
        #endregion

        #region turning data into string
        var sB = new StringBuilder();

        while (newNumber.Count > 0)
            sB.Append(newNumber.Pop());
        #endregion

        return new BigNumber(sB.ToString());
    }

    public static BigNumber operator *(BigNumber bn, int num)
    {
        var newNumber = new Stack<sbyte>();

        sbyte remainder = 0;
        while(bn.number.Count!=0)
        {
            sbyte mult = (sbyte)(bn.number.Pop() * num + remainder);
            remainder = (sbyte)(mult / 10);
            mult %= 10;
            newNumber.Push(mult);
        }
        if (remainder > 0)
            newNumber.Push(remainder);

        var sB = new StringBuilder();
        while (newNumber.Count != 0)
            sB.Append(newNumber.Pop());
        return new BigNumber(sB.ToString());
    }

    public override string ToString()
    {
        var number = this.number.Reverse().ToList();
        while (number[0] == 0&&number.Count>1)
            number.RemoveAt(0);
        return string.Join("", number);
    }
}

class Program
{
    static void Main()
    {
        var n = new BigNumber(ReadLine());
        var m = int.Parse(ReadLine());
        var o = n * m;
        WriteLine(o);
    }

}