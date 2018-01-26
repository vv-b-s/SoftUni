using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

class BalancedParentheses
{
    static void Main(string[] args)
    {
        string input = ReadLine();
        var parantheses = new Stack<char>();
        var paranthesesMatch = true;
        var openingParantheses = new char[] { '(', '{', '[' };

        if (input.Length % 2 == 0)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if(openingParantheses.Contains(input[i]))
                    parantheses.Push(input[i]);
                else
                { //It is important to notice here that "balanced" does not mean "symmetric". Only requirements are parantheses to have closing pair and equal intervals
                    char paranthese = parantheses.Pop();
                    switch (paranthese)
                    {
                        case '(':
                            paranthesesMatch = input[i] == ')';
                            break;
                        case '[':
                            paranthesesMatch = input[i] == ']';
                            break;
                        case '{':
                            paranthesesMatch = input[i] == '}';
                            break;
                        default:
                            paranthesesMatch = false;
                            break;
                    }
                    if (!paranthesesMatch)
                        break;
                }
            }
        }
        else paranthesesMatch = false;

        WriteLine(paranthesesMatch ? "YES" : "NO");
    }
}