using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

class MatchingBrakcets
{
    static void Main()
    {
        string expression = ReadLine();

        var bracketKeeper = new Stack<int>();

        for(int i = 0; i < expression.Length; i++)
        {
            //If a bracket is opened the index will be kept in the stack
            if (expression[i] == '(')
                bracketKeeper.Push(i);

            //When the bracket is closed, the stack will pop the startindex and we have the interval of the braket expression
            if(expression[i]==')')
            {
                var sB = new StringBuilder();
                for (int s = bracketKeeper.Pop(); s <= i; s++)
                    sB.Append(expression[s]);

                WriteLine(sB.ToString());
            }
        }
    }
}
